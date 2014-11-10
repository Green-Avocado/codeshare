using System.Collections.Generic;
using System.Linq;
using CodeShare.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeShare.Data.Test
{
    [TestClass]
    public class PagedResultTest
    {
        [TestMethod]
        public void ConstructorShouldInitializeItemsAndCount()
        { 
            // Arrange
            var projects = new List<Project>
            {
                new Project { Id = 333 },
                new Project { Id = 1667 }
            };
            PagedResult<Project> pagedResult;

            // Act
            pagedResult =  new PagedResult<Project>(projects, 100);

            // Assert
            Assert.IsNotNull(pagedResult);
            Assert.AreEqual(100, pagedResult.TotalCount);
            Assert.IsNotNull(pagedResult.Items);
            Assert.AreEqual(333, pagedResult.Items.ToList()[0].Id);
            Assert.AreEqual(1667, pagedResult.Items.ToList()[1].Id);
        }
    }
}