using CodeShare.Api.Models;
using CodeShare.Application;
using CodeShare.Core;
using System.Web.Http;
using System.Linq;
using System;
using System.Net.Http;
using System.Net;

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

        [HttpGet]
        [Route("")]
        public PagedProjectInfo Search(string name, int page = 0, int pageSize = 10)
        {
            try
            {
                var projectService = new ProjectService();
                var paged = projectService.Search(name, page, pageSize);
                var result = new PagedProjectInfo
                {
                    Items = paged.Items.Select(p => ProjectHelper.GetProjectInfoFromProject(p)),
                    TotalCount = paged.TotalCount
                };

                return result;
            }
            catch(ArgumentException)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, Resources.Messages.EmptyProjectName));
            }
        }
    }
}