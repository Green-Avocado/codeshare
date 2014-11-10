using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeShare.Core.Test
{
    [TestClass]
    public class ProjectTest
    {
        [TestMethod]
        public void ConstructorShouldInitializeCollections()
        {
            // Arrange
            Project project;

            // Act
            project = new Project();

            // Assert
            Assert.IsNotNull(project.Likes);
            Assert.IsNotNull(project.Followers);
            Assert.IsNotNull(project.Members);
            Assert.IsNotNull(project.MemberRequests);
            Assert.IsNotNull(project.Openings);
            Assert.IsNotNull(project.Tags);
            Assert.IsNotNull(project.Releases);
        }
    }
}