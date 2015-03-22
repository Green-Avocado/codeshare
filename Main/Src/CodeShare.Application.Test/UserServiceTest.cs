using System;
using CodeShare.Core;
using CodeShare.Data;
using CrossCutting.MainModule.IOC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeShare.Application.Test
{
    [TestClass]
    public class UserServiceTest
    {
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
        public void GetUserInfoWithValidUserShouldReturnUser()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            var userName = @"Globant\mario.moreno";
            User actual;

            // Act
            actual = userService.GetUserByName(userName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Id);
        }

        [TestMethod]
        public void GetUserInfoWithNonExistingUserShouldReturnNull()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            var userName = "samus.aran";
            User actual;

            // Act
            actual = userService.GetUserByName(userName);

            // Assert
            Assert.IsNull(actual);
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
        public void CreateUserShouldAddNewUser()
        {
            // Arrange
            var userService = IocUnityContainer.Instance.Resolve<IUserService>();
            var userName = @"domain\samus.aran";
            User actual;

            // Act
            actual = userService.CreateUser(userName, string.Empty);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(DateTime.Now.Day, actual.JoinDate.Day);
            Assert.AreEqual(DateTime.Now.Hour, actual.JoinDate.Hour);
            Assert.AreEqual(DateTime.Now.Minute, actual.JoinDate.Minute);
            Assert.AreEqual(userName, actual.UserName);
            Assert.AreEqual("samus.aran", actual.NickName);
        }
    }
}