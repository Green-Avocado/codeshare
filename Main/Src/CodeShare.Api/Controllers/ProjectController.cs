using CodeShare.Api.Models;
using CodeShare.Application;
using CodeShare.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CodeShare.Api.Controllers
{
    [Authorize]
    [RoutePrefix("v1/projects")]
    public class ProjectController : ApiController
    {
        [HttpPost]
        [Route("")]
        public ProjectInfo CreateProject([FromBody]ProjectInfo project)
        {
            var projectService = new ProjectService();
            try
            {
                var userId = UserHelper.GetCurrentUserInfo().Id;
                var newProject = projectService.CreateProject(project.Name, project.QuickDescription, userId);
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
            var projectService = new ProjectService();
            var project = projectService.GetProject(id);
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
            var projectService = new ProjectService();
            var latestProjectInfo = projectService.GetLatestProjects(top).Select(p => ProjectHelper.GetProjectInfoFromProject(p)).ToList();

            return latestProjectInfo;
        }

        [HttpPut]
        [Route("")]
        public ProjectInfo UpdateProject([FromBody]ProjectInfo projectInfo)
        {
            var projectService = new ProjectService();
            var userId = UserHelper.GetCurrentUserInfo().Id;
            if (projectService.IsProjectMember(userId, projectInfo.Id))
            {
                try
                {
                    var updatedProject = projectService.UpdateProjectInfo(projectInfo.Id, projectInfo.QuickDescription, projectInfo.Description, projectInfo.LogoUrl);
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