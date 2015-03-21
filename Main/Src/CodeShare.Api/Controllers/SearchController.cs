using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeShare.Api.Models;
using CodeShare.Application;

namespace CodeShare.Api.Controllers
{
    [Authorize]
    [RoutePrefix("v1/search")]
    public class SearchController : ApiController
    {
        /*
            [{ProjectInfo}] GET /projects/search?{query:string}&{top:int}
            [{ProjectInfo}] GET /projects/advancedsearch?{query:string}&state=open&sort=-priority,created_at&{top:int}
            [{ProjectOpeningInfo}] GET /projects/openings/search?{query:string}
         */

        private IProjectService _projectService;

        public SearchController(IProjectService projectService)
        {
            if (projectService == null)
            {
                throw new ArgumentNullException("projectService");
            }

            _projectService = projectService;
        }

        [HttpGet]
        [Route("")]
        public PagedProjectInfo Search(string name, int page = 0, int pageSize = 10)
        {
            try
            {
                var paged = _projectService.Search(name, page, pageSize);
                var result = new PagedProjectInfo
                {
                    Items = paged.Items.Select(p => ProjectHelper.GetProjectInfoFromProject(p)),
                    TotalCount = paged.TotalCount
                };

                return result;
            }
            catch (ArgumentException)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, Resources.Messages.EmptyProjectName));
            }
        }
    }
}