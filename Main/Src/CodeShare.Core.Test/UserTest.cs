using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeShare.Core.Test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ConstructorShouldInitializeCollections()
        {
            // Arrange
            User user;

            // Act
            user = new User();

            // Assert
            Assert.IsNotNull(user.Following);
            Assert.IsNotNull(user.CreatorOf);
            Assert.IsNotNull(user.AdministratorFor);
            Assert.IsNotNull(user.ContributorFor);
        }
    }
}