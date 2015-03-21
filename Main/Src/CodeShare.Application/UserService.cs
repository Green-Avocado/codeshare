using System;
using System.Linq;
using System.Web;
using CodeShare.Core;
using CodeShare.Data;
using CrossCutting.Core.Logging;

namespace CodeShare.Application
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private ILogManager _logManager;

        public UserService(IUnitOfWork unitOfWork, ILogManager logManager)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            if (logManager == null)
            {
                throw new ArgumentNullException("logManager");
            }

            _unitOfWork = unitOfWork;
            _logManager = logManager;
        }

        public User GetUserById(int id)
        {
            try
            {
                return _unitOfWork.UserRepository.Search(u => u.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logManager.DefaultLogger.Error.Write("CodeShare.Application.UserService.GetUserById", ex);
                return null;
            }
        }

        public User GetUserByName(string userName)
        {
            try
            {
                return _unitOfWork.UserRepository.Search(u => u.UserName == userName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logManager.DefaultLogger.Error.Write("CodeShare.Application.UserService.GetUserByName", ex);
                return null;
            }
        }

        public User GetCurrentUser()
        {
            if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userName = HttpContext.Current.User.Identity.Name;

                return GetUserByName(userName);
            }

            return null;
        }

        public User CreateUser(string userName, string defaultAvatarUrl)
        {
            try
            {
                var user = GetUserByName(userName);

                if (user == null)
                {
                    user = new User
                    {
                        UserName = userName,
                        NickName = NameWithoutDomain(userName),
                        JoinDate = DateTime.Now,
                        AvatarUrl = defaultAvatarUrl
                    };

                    _unitOfWork.UserRepository.Insert(user);
                    _unitOfWork.Save();
                }

                return user;
            }
            catch (Exception ex)
            {
                _logManager.DefaultLogger.Error.Write("CodeShare.Application.UserService.CreateUser", ex);
                return null;
            }
        }

        public string NameWithoutDomain(string userName)
        {
            int indexOf = userName.IndexOf("\\");
            if (indexOf != -1)
            {
                userName = userName.Substring(indexOf + 1, userName.Length - indexOf - 1);
            }

            return userName;
        }

        public User UpdateUser(int id, string nickName, string avatarUrl)
        {
            if (string.IsNullOrEmpty(nickName))
            {
                throw new ArgumentNullException("nickName");
            }

            if (string.IsNullOrEmpty(nickName))
            {
                throw new ArgumentNullException("avatarUrl");
            }

            try
            {
                var user = _unitOfWork.UserRepository.Get(id);
                user.NickName = nickName;
                user.AvatarUrl = avatarUrl;

                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.Save();

                return user;
            }
            catch (Exception ex)
            {
                _logManager.DefaultLogger.Error.Write("CodeShare.Application.UserService.UpdateUser", ex);
                return null;
            }
        }
    }
}