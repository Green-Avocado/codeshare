using System.Web;
using System.Linq;
using System.Web.Mvc;
using CodeShare.Application;
using CodeShare.Core;
using CodeShare.Web.Models;

namespace CodeShare.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var applicationHomeInfo = new ApplicationHomeInfo();

            var projectService = new ProjectService();
            applicationHomeInfo.NewProjectInfoList = projectService.GetLatestProjects(5).Select(p => new NewProjectInfo { Id = p.Id, Name = p.Name, QuickDescription = p.QuickDescription } ).ToList();

            return View(applicationHomeInfo);
        }
    }
}