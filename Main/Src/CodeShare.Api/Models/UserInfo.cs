using System;

namespace CodeShare.Api.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string NickName { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime JoinDate { get; set; }
    }
}