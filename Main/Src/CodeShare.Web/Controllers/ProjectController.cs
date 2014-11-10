using System.Linq;
using System.Web.Mvc;
using CodeShare.Application;
using CodeShare.Core;
using CodeShare.Web.Models;

namespace CodeShare.Web.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            var projectService = new ProjectService();
            var userService = new UserService();
            var user = userService.GetUserByName(Session["UserName"].ToString());
            var newProject = projectService.CreateProject(project.Name, project.QuickDescription, user.Id);
            return RedirectToAction("Home", new {id = newProject.Id } );
        }

        public ActionResult Home(int id)
        {
            var projectService = new ProjectService();
            var project = projectService.GetProject(id);
            return View(project);        
        }

        public ActionResult HomeEdit(int id)
        {
            var projectService = new ProjectService();
            var project = projectService.GetProject(id);
            return View(project);
        }

        [HttpPost]
        public ActionResult HomeEdit(Project project)
        {
            var projectService = new ProjectService();
            projectService.UpdateProjectInfo(project.Id, project.QuickDescription, project.Description, project.LogoUrl);
            return RedirectToAction("Home", new { id = project.Id });
        }

        [HttpPost]
        public ActionResult SourceCodeEdit(Project project)
        {
            var projectService = new ProjectService();
            projectService.UpdateProjectSourceUrl(project.Id, project.SourceUrl);
            return RedirectToAction("SourceCode", new { id = project.Id });
        }

        public ActionResult SourceCode(int id)
        {
            var projectService = new ProjectService();
            var project = projectService.GetProject(id);
            return View(project);
        }

        public ActionResult Download(int id)
        {
            var projectService = new ProjectService();
            var project = projectService.GetProjectWithReleases(id);
            var downloadInfo = new DownloadInfo();
            downloadInfo.Id = project.Id;
            downloadInfo.Name = project.Name;
            downloadInfo.LogoUrl = project.LogoUrl;
            downloadInfo.QuickDescription = project.QuickDescription;
            downloadInfo.CurrentRelease = project.Releases.Count == 0 ? null : project.Releases.FirstOrDefault();
            project.Releases.Remove(downloadInfo.CurrentRelease);
            downloadInfo.Releases = project.Releases.ToList();
            return View(downloadInfo);
        }

        public ActionResult DownloadEdit(int projectId, int releaseId)
        {
            var projectService = new ProjectService();
            var project = projectService.GetProjectWithReleases(projectId);
            return View(project.Releases.FirstOrDefault());
        }

        public ActionResult DownloadNew(int id)
        {
            return View();
        }

        public ActionResult Team(int id)
        {
            var projectService = new ProjectService();
            var project = projectService.GetProject(id);
            return View(project);
        }

        public ActionResult IssueTracker(int id)
        {
            var projectService = new ProjectService();
            var project = projectService.GetProject(id);
            return View(project);
        }

        public ActionResult SourceCodeEdit(int id)
        { 
            var projectService = new ProjectService();
            var project = projectService.GetProject(id);
            return View(project);
        }
    }
}