using System;
using CodeShare.Core;
using CodeShare.Data;

namespace CrossCutting.MainModule.Fake
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        GenericRepository<User> _fakeUserRepository;

        public FakeUnitOfWork()
        {
            var fakeEntities = new FakeCodeShareEntities();

            _fakeUserRepository = new GenericRepository<User>(fakeEntities);
        }

        public GenericRepository<ProjectFile> ProjectFileRepository
        {
            get { throw new NotImplementedException(); }
        }

        public GenericRepository<ProjectOpening> ProjectOpeningRepository
        {
            get { throw new NotImplementedException(); }
        }

        public GenericRepository<ProjectRelease> ProjectReleaseRepository
        {
            get { throw new NotImplementedException(); }
        }

        public GenericRepository<Project> ProjectRepository
        {
            get { throw new NotImplementedException(); }
        }

        public GenericRepository<ProjectUser> ProjectUserRepository
        {
            get { throw new NotImplementedException(); }
        }

        public GenericRepository<ProjectUserRequest> ProjectUserRequestRepository
        {
            get { throw new NotImplementedException(); }
        }

        public void Save()
        {
            // do nothing
        }

        public GenericRepository<Tag> TagRepository
        {
            get { throw new NotImplementedException(); }
        }

        public GenericRepository<User> UserRepository
        {
            get { return _fakeUserRepository; }
        }

        public void Dispose()
        {
            // do nothing
        }
    }
}