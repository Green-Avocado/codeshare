using System;
using CodeShare.Data;
using CrossCutting.Core.Logging;
using CrossCutting.MainModule.IOC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeShare.Application.Test
{
    [TestClass]
    public class ProjectServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullUnitOfWorkShouldThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork unitOfWork = null;
            var logManager = IocUnityContainer.Instance.Resolve<ILogManager>();

            // Act
            new ProjectService(unitOfWork, logManager);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullLogManagerShouldThrowArgumentNullException()
        {
            // Arrange
            var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>();
            ILogManager logManager = null;

            // Act
            new ProjectService(unitOfWork, logManager);
        }

        [TestMethod]

    }
}
