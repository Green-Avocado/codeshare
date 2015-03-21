using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeShare.Api.Models;
using CodeShare.Application;
using CodeShare.Core;

namespace CodeShare.Api.Controllers
{
    [Authorize]
    [RoutePrefix("v1/users")]
    public class UserController : ApiController
    {
        private IUserService _userService;

        private UserInfo GetUserInfoFromUser(User user)
        {
            return new UserInfo
            {
                Id = user.Id,
                UserName = user.UserName,
                NickName = user.NickName,
                JoinDate = user.JoinDate,
                AvatarUrl = user.AvatarUrl
            };
        }

        public UserController(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("userService");
            }

            _userService = userService;
        }

        [HttpGet]
        [Route("current")]
        public UserInfo GetCurrentUserInfo()
        {
            var currentUser = _userService.GetCurrentUser();
            if(currentUser != null)
            {
                return GetUserInfoFromUser(currentUser);
            }

            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, Resources.Messages.UserUnauthorized));
        }

        [HttpGet]
        [Route("{id:int}")]
        public UserInfo Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user != null)
            {
                return GetUserInfoFromUser(user);
            }

            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, Resources.Messages.UserUnauthorized));
        }
        
        [HttpPost]
        [Route("")]
        public UserInfo CreateUser([FromBody]UserInfo user)
        {
            var newUser = _userService.CreateUser(user.UserName, user.AvatarUrl);
            return GetUserInfoFromUser(newUser);
        }

        [HttpPut]
        [Route("")]
        public UserInfo UpdateUser([FromBody]UserInfo user)
        {
            var currentUser = _userService.GetCurrentUser();
            try
            {
                var updatedUser = _userService.UpdateUser(currentUser.Id, user.NickName, user.AvatarUrl);
                return GetUserInfoFromUser(updatedUser);
            }
            catch (ArgumentNullException aex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, aex));
            }
        }
    }
}