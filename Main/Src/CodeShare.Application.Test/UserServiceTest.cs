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
        public void NameWithoutDomainWiththoutDomainShouldReturnUserName()
        { 
            // Arrange
            var userService = new UserService();
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
            var userService = new UserService();
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
            var userService = new UserService();
            var userName = "mario.moreno";
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
            var userService = new UserService();
            var userName = "samus.aran";
            User actual;

            // Act
            actual = userService.GetUserByName(userName);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void CreateUserShouldAddNewUser()
        {
            // Arrange
            var userService = new UserService();
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