using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CodeShare.Application;
using CrossCutting.Core.Logging;
using CrossCutting.MainModule.IOC;

namespace CodeShare.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private string _defaultAvatarUrl;

        public string DefaultAvatarUrl
        {
            get 
            {
                if (_defaultAvatarUrl == null)
                {
                    var avatarUri = System.Configuration.ConfigurationManager.AppSettings["DefaultAvatarUri"];
                    _defaultAvatarUrl = string.Format("{0}://{1}/{2}", Request.Url.Scheme, Request.Url.Authority, avatarUri);
                    return _defaultAvatarUrl;
                }
                
                return _defaultAvatarUrl; 
            }
        }
        

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            var userName = HttpContext.Current.User.Identity.Name;
            var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
            logger.DefaultLogger.Information.Write(string.Format("User {0} logged", userName));
            var userService = new UserService();
            var user = userService.CreateUser(userName, DefaultAvatarUrl);
            Session["UserName"] = user.UserName;
            Session["UserNickName"] = user.NickName;
            Session["UserAvatarUrl"] = user.AvatarUrl;
        }
    }
}