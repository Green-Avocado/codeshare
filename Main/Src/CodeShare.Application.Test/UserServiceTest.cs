using System;
using System.Linq;
using System.Linq.Expressions;
using CodeShare.Core;
using CodeShare.Data;
using CrossCutting.Core.Logging;
using CrossCutting.MainModule.Fake;
using CrossCutting.MainModule.IOC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeShare.Application.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullUnitOfWorkShouldThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork unitOfWork = null;
            var logManager = IocUnityContainer.Instance.Resolve<ILogManager>();

            // Act
            new UserService(unitOfWork, logManager);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullLogManagerShouldThrowArgumentNullException()
        {
            // Arrange
            var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>();
            ILogManager logManager = null;

            // Act
            new UserService(unitOfWork, logManager);
        }

        [TestMethod]
        public void GetUserByIdWithExistingIdShouldReturnUser()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            int userId = 1;
            User existingUser;

            // Act 
            existingUser = userService.GetUserById(userId);

            // Assert
            Assert.AreEqual("mario.moreno", existingUser.NickName);
        }

        [TestMethod]
        public void GetUserByIdWithNonExistingIdShouldReturnNull()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            int userId = 99;
            User nullUser;

            // Act 
            nullUser = userService.GetUserById(userId);

            // Assert
            Assert.IsNull(nullUser);
        }

        [TestMethod]
        public void GetUserByNameWithExistingNameShouldReturnUser()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            string userName = @"Globant\mario.moreno";
            User existingUser;
            string avatarUrl = "http://codeshare.globant.com/avatars/default.png";

            // Act 
            existingUser = userService.GetUserByName(userName);

            // Assert
            Assert.AreEqual(avatarUrl, existingUser.AvatarUrl);
        }

        [TestMethod]
        public void GetUserByNameWithNonExistingNameShouldReturnNull()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            string userName = @"Globant\fake.user";
            User nullUser;

            // Act 
            nullUser = userService.GetUserByName(userName);

            // Assert
            Assert.IsNull(nullUser);
        }

        [TestMethod]
        public void GetCurrentUserWithNonHttpContextShouldReturnNull()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            User nullUser;

            // Act 
            nullUser = userService.GetCurrentUser();

            // Assert
            Assert.IsNull(nullUser);
        }

        [TestMethod]
        public void CreateUserWithNonExistingNameShouldAddUser()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            string userName = @"Globant\mario.moreno";
            string avatarUrl = "http://codeshare.globant.com/avatars/default.png";
            User newUser;

            // Act
            newUser = userService.CreateUser(userName, avatarUrl);

            // Assert
            Assert.AreEqual(10, newUser.JoinDate.Day);
            Assert.AreEqual(1980, newUser.JoinDate.Year);
            Assert.AreEqual(5, newUser.JoinDate.Month);
            Assert.AreEqual(userName, newUser.UserName);
            Assert.AreEqual("mario.moreno", newUser.NickName);
            Assert.AreEqual(avatarUrl, newUser.AvatarUrl);
        }

        [TestMethod]
        public void CreateUserWithExistingNameShouldReturnExistingUser()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            string userName = @"domain\jim.raynor";
            string avatarUrl = "http://www.domain.com/avatar.png";
            User newUser;

            // Act
            newUser = userService.CreateUser(userName, avatarUrl);

            // Assert
            Assert.AreEqual(DateTime.Today.Day, newUser.JoinDate.Day);
            Assert.AreEqual(DateTime.Today.Year, newUser.JoinDate.Year);
            Assert.AreEqual(DateTime.Today.Month, newUser.JoinDate.Month);
            Assert.AreEqual(userName, newUser.UserName);
            Assert.AreEqual("jim.raynor", newUser.NickName);
            Assert.AreEqual(avatarUrl, newUser.AvatarUrl);
        }

        [TestMethod]
        public void NameWithoutDomainWiththoutADomainShouldReturnUserName()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            string output;
            string userName = "mario.moreno";

            // Act
            output = userService.NameWithoutDomain(userName);

            // Assert
            Assert.AreEqual("mario.moreno", output);
        }

        [TestMethod]
        public void NameWithDomainWiththoutDomainShouldReturnUserName()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            string output;
            string userName = @"domain\mario.moreno";

            // Act
            output = userService.NameWithoutDomain(userName);

            // Assert
            Assert.AreEqual("mario.moreno", output);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateUserWithNullNicknameShouldThrowArgumentNullException()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            int id = 1;
            string nickName = null;
            string avatarUrl = "http://codeshare.globant.com/avatars/default.png";

            // Act
            userService.UpdateUser(id, nickName, avatarUrl);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateUserWithNullAvatarUrlShouldThrowArgumentNullException()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            int id = 1;
            string nickName = "mario.moreno";
            string avatarUrl = null;

            // Act
            userService.UpdateUser(id, nickName, avatarUrl);
        }

        [TestMethod]
        public void UpdateUserShouldUpdateNickNameAndAvatarUrl()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            int id = 1;
            string nickName = "mario.moreno2";
            string avatarUrl = "http://www.google.com/avatar.png";
            User updatedUser;

            // Act
            updatedUser = userService.UpdateUser(id, nickName, avatarUrl);

            // Assert
            Assert.AreEqual(nickName, updatedUser.NickName);
            Assert.AreEqual(@"Globant\mario.moreno", updatedUser.UserName);
            Assert.AreEqual(avatarUrl, updatedUser.AvatarUrl);
        }
    }
}