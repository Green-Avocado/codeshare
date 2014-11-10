using System.Web.Mvc;
using CodeShare.Application;
using CodeShare.Core;

namespace CodeShare.Web.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Details()
        {
            var userService = new UserService();
            var user = userService.GetUserByName(Session["UserName"].ToString());
            return View(user);
        }

        public ActionResult Edit()
        {
            var userService = new UserService();
            var user = userService.GetUserByName(Session["UserName"].ToString());
            return View(user);        
        }

        [HttpPost]
        public ActionResult Edit(User modifiedUser)
        {
            var userService = new UserService();
            userService.UpdateUser(modifiedUser.Id, modifiedUser.NickName, modifiedUser.AvatarUrl);
            Session["UserNickName"] = modifiedUser.NickName;
            Session["UserAvatarUrl"] = modifiedUser.AvatarUrl;

            return RedirectToAction("Details");
        }
    }
}