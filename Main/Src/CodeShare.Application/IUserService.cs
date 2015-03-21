using System;
using CodeShare.Core;

namespace CodeShare.Application
{
    public interface IUserService
    {
        User CreateUser(string userName, string defaultAvatarUrl);
        
        User GetUserById(int id);
        
        User GetUserByName(string userName);

        User GetCurrentUser();
        
        string NameWithoutDomain(string userName);
        
        User UpdateUser(int id, string nickName, string avatarUrl);
    }
}