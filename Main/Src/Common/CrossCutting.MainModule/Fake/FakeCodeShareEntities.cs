using System;
using System.Collections.Generic;
using System.Data.Entity;
using CodeShare.Core;
using CodeShare.Data;

namespace CrossCutting.MainModule.Fake
{
    public class FakeCodeShareEntities : ICodeShareEntities
    {
        private Dictionary<Type, object> _dbSets;

        public FakeCodeShareEntities()
        {
            _dbSets = new Dictionary<Type, object>();

            var fakeUserDbSet = new FakeDbSet<User>();
            fakeUserDbSet.Add(
                new User
            {
                Id = 1,
                UserName = "mario.moreno",
                JoinDate = new DateTime(1980, 5, 10)
            }
            );

            _dbSets[typeof(User)] = fakeUserDbSet;
        }

        public DbSet<Project> Projects
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DbSet<ProjectFile> ProjectFiles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DbSet<ProjectOpening> ProjectOpenings
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DbSet<ProjectRelease> ProjectReleases
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DbSet<ProjectUser> ProjectUsers
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DbSet<ProjectUserRequest> ProjectUserRequests
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DbSet<Tag> Tags
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DbSet<User> Users
        {
            get
            {
                return (DbSet<User>)_dbSets[typeof(User)];
            }
            set
            {
                // do nothing
            }
        }

        public EntityState GetState(object entity)
        {
            return EntityState.Modified;
        }

        public void SetModified(object entity)
        {
            // do nothing
        }

        public DbSet<T> GetSet<T>() where T : class
        {
            return (DbSet<T>)_dbSets[typeof(T)];
        }
    }
}