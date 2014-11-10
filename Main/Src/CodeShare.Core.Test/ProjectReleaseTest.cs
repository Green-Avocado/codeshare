using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeShare.Core.Test
{
    [TestClass]
    public class ProjectReleaseTest
    {
        [TestMethod]
        public void ConstructorShouldInitializeCollections()
        {
            // Arrange
            ProjectRelease projectRelease;

            // Act
            projectRelease = new ProjectRelease();

            // Assert
            Assert.IsNotNull(projectRelease.Files);
        }
    }
}
