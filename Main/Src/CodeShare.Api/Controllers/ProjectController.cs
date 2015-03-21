using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeShare.Api.Models;
using CodeShare.Application;

namespace CodeShare.Api.Controllers
{
    [Authorize]
    [RoutePrefix("v1/projects")]
    public class ProjectController : ApiController
    {
        private IProjectService _projectService;
        private IUserService _userService;

        public ProjectController(IProjectService projectService, IUserService userService)
        {
            _projectService = projectService;
            _userService = userService;
        }

        [HttpPost]
        [Route("")]
        public ProjectInfo CreateProject([FromBody]ProjectInfo project)
        {
            try
            {
                var user = _userService.GetCurrentUser();
                var newProject = _projectService.CreateProject(project.Name, project.QuickDescription, user.Id);
                return ProjectHelper.GetProjectInfoFromProject(newProject);
            }
            catch (ArgumentException aex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, aex.Message));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public ProjectInfo GetProjectById(int id)
        {
            var project = _projectService.GetProject(id);
            if (project != null)
            {
                return new ProjectInfo
                {
                    Id = project.Id,
                    Name = project.Name,
                    QuickDescription = project.QuickDescription,
                    SourceUrl = project.SourceUrl,
                    LogoUrl = project.LogoUrl,
                    CreationDate = project.CreationDate,
                    Description = project.Description
                };
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Resources.Messages.ProjectIdNotFound, id)));   
            }
        }

        [HttpGet]
        [Route("latest")]
        public IEnumerable<ProjectInfo> GetLatestProjects(int top = 10)
        {
            var latestProjectInfo = _projectService.GetLatestProjects(top).Select(p => ProjectHelper.GetProjectInfoFromProject(p)).ToList();

            return latestProjectInfo;
        }

        [HttpPut]
        [Route("")]
        public ProjectInfo UpdateProject([FromBody]ProjectInfo projectInfo)
        {
            var user = _userService.GetCurrentUser();
            if (_projectService.IsProjectMember(user.Id, projectInfo.Id))
            {
                try
                {
                    var updatedProject = _projectService.UpdateProjectInfo(projectInfo.Id, projectInfo.QuickDescription, projectInfo.Description, projectInfo.LogoUrl);
                    return ProjectHelper.GetProjectInfoFromProject(updatedProject);
                }
                catch (Exception ex)
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
                }
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, Resources.Messages.UserNotInProject));
            }
        }
    }
}