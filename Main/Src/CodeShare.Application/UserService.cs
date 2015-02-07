using System;
using System.Linq;
using CodeShare.Core;
using CodeShare.Data;
using CrossCutting.Core.Logging;
using CrossCutting.MainModule.IOC;

namespace CodeShare.Application
{
    public class UserService
    {
        public User GetUserById(int id)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    return unitOfWork.UserRepository.Search(u => u.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.UserService.GetUserById", ex);
                return null;
            }
        }

        public User GetUserByName(string userName)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    return unitOfWork.UserRepository.Search(u => u.UserName == userName).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.UserService.GetUserByName", ex);
                return null;
            }
        }

        public User CreateUser(string userName, string defaultAvatarUrl)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
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

                        unitOfWork.UserRepository.Insert(user);
                        unitOfWork.Save();
                    }

                    return user;
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.UserService.CreateUser", ex);
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
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    var user = unitOfWork.UserRepository.Get(id);
                    user.NickName = nickName;
                    user.AvatarUrl = avatarUrl;

                    unitOfWork.UserRepository.Update(user);
                    unitOfWork.Save();

                    return user;
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.UserService.UpdateUser", ex);
                return null;
            }
        }
    }
}