using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CodeShare.Data;
using System.Data.Entity;
using CodeShare.Core;
using System;

namespace CodeShare.Data.Test
{
    [TestClass]
    public class GenericRepositoryTest
    {
        //[TestMethod]
        //[Ignore]
        //public void GetShouldReturnDbSetFind()
        //{
        //    // Arrange
        //    var CodeShareEntitiesMock = new Mock<CodeShareEntities>();
        //    var dbSetMock = new Mock<DbSet<Project>>();
        //    var name = "Test Project";
        //    var project = new Project { Id = 1, Name = name, QuickDescription = "Quick Description", CreationDate = DateTime.Now };
        //    dbSetMock.Setup(s => s.Find(It.IsAny<object[]>())).Returns(project).Verifiable();
        //    CodeShareEntitiesMock.Setup(pb => pb.Set<Project>()).Returns(dbSetMock.Object);
        //    var projectRepository = new GenericRepository<Project>(CodeShareEntitiesMock.Object);
        //    Project result;

        //    // Act
        //    result = projectRepository.Get(1);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(name, result.Name);
        //    dbSetMock.VerifyAll();
        //}

        //[TestMethod]
        //[Ignore]
        //public void InsertShouldCallDbSetAdd()
        //{
        //    // Arrange
        //    var CodeShareEntitiesMock = new Mock<CodeShareEntities>();
        //    var dbSetMock = new Mock<DbSet<Project>>();
        //    var project = new Project { Name = "Test Project", QuickDescription = "Quick Description", CreationDate = DateTime.Now };
        //    dbSetMock.Setup(s => s.Add(It.IsAny<Project>())).Returns(project).Verifiable();
        //    CodeShareEntitiesMock.Setup(pb => pb.Set<Project>()).Returns(dbSetMock.Object);
        //    var projectRepository = new GenericRepository<Project>(CodeShareEntitiesMock.Object);

        //    // Act
        //    projectRepository.Insert(project);

        //    // Assert
        //    dbSetMock.VerifyAll();
        //}

        [TestMethod]
        public void DeleteWithEntityAlreadyAddedShouldCallDbSetRemove()
        {
            // Arrange
            var CodeShareEntitiesMock = new Mock<ICodeShareEntities>();
            var dbSetMock = new Mock<DbSet<Project>>();
            var project = new Project { Name = "Test Project", QuickDescription = "Quick Description", CreationDate = DateTime.Now };
            dbSetMock.Setup(s => s.Remove(It.IsAny<Project>())).Returns(project).Verifiable();
            CodeShareEntitiesMock.Setup(pb => pb.GetSet<Project>()).Returns(dbSetMock.Object);
            CodeShareEntitiesMock.Setup(pb => pb.GetState(project)).Returns(EntityState.Added);
            var projectRepository = new GenericRepository<Project>(CodeShareEntitiesMock.Object);

            // Act
            projectRepository.Delete(project);

            // Assert
            dbSetMock.VerifyAll();
        }

        [TestMethod]
        public void DeleteWithEntityDetachedShouldAttachItBeforeCallRemove()
        {
            // Arrange
            var CodeShareEntitiesMock = new Mock<ICodeShareEntities>();
            var dbSetMock = new Mock<DbSet<Project>>();
            var project = new Project { Name = "Test Project", QuickDescription = "Quick Description", CreationDate = DateTime.Now };
            dbSetMock.Setup(s => s.Remove(It.IsAny<Project>())).Returns(project).Verifiable();
            dbSetMock.Setup(s => s.Attach(It.IsAny<Project>())).Verifiable();
            CodeShareEntitiesMock.Setup(pb => pb.GetSet<Project>()).Returns(dbSetMock.Object);
            CodeShareEntitiesMock.Setup(pb => pb.GetState(project)).Returns(EntityState.Detached);
            var projectRepository = new GenericRepository<Project>(CodeShareEntitiesMock.Object);

            // Act
            projectRepository.Delete(project);

            // Assert
            dbSetMock.VerifyAll();
        }

        [TestMethod]
        public void UpdateShouldAttachAndCallSetModified()
        {
            // Arrange
            var CodeShareEntitiesMock = new Mock<ICodeShareEntities>();
            var dbSetMock = new Mock<DbSet<Project>>();
            var project = new Project { Name = "Test Project", QuickDescription = "Quick Description", CreationDate = DateTime.Now };
            dbSetMock.Setup(s => s.Attach(It.IsAny<Project>())).Verifiable();
            CodeShareEntitiesMock.Setup(pb => pb.GetSet<Project>()).Returns(dbSetMock.Object);
            CodeShareEntitiesMock.Setup(pb => pb.SetModified(project)).Verifiable();
            var projectRepository = new GenericRepository<Project>(CodeShareEntitiesMock.Object);

            // Act
            projectRepository.Update(project);

            // Assert
            dbSetMock.VerifyAll();
        }
    }
}
