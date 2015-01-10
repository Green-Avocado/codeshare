using CodeShare.Application;
using CodeShare.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShare.Api.Models
{
    public class UserHelper
    {
        public static UserInfo GetUserInfoFromUser(User user)
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

        public static UserInfo GetCurrentUserInfo()
        {
            if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userName = HttpContext.Current.User.Identity.Name;
                var userService = new UserService();
                var user = userService.GetUserByName(userName);
                if (user != null)
                {
                    return GetUserInfoFromUser(user);
                }
            }

            return null;
        }
    }
}