using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeShare.Core.Test
{
    [TestClass]
    public class ProjectOpeningTest
    {
        [TestMethod]
        public void ConstructorShouldInitializeCollections()
        {
            // Arrange
            ProjectOpening projectOpening;

            // Act
            projectOpening = new ProjectOpening();

            // Assert
            Assert.IsNotNull(projectOpening.Tags);
        }
    }
}