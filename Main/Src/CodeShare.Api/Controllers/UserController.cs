using CodeShare.Api.Models;
using CodeShare.Application;
using CodeShare.Core;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CodeShare.Api.Controllers
{
    [Authorize]
    [RoutePrefix("v1/users")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("current")]
        public UserInfo GetCurrentUser()
        {
            var currentUser = UserHelper.GetCurrentUserInfo();
            if(currentUser != null)
            {
                return currentUser;
            }

            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, Resources.Messages.UserUnauthorized));
        }

        [HttpPost]
        [Route("")]
        public UserInfo CreateUser([FromBody]UserInfo user)
        {
            var userService = new UserService();
            var newUser = userService.CreateUser(user.UserName, user.AvatarUrl);
            return UserHelper.GetUserInfoFromUser(newUser);
        }

        [HttpPut]
        [Route("")]
        public UserInfo UpdateUser([FromBody]UserInfo user)
        {
            var userId = UserHelper.GetCurrentUserInfo().Id;
            var userService = new UserService();
            try
            {
                var updatedUser = userService.UpdateUser(userId, user.NickName, user.AvatarUrl);
                return UserHelper.GetUserInfoFromUser(updatedUser);
            }
            catch (ArgumentNullException aex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, aex));
            }
        }
    }
}