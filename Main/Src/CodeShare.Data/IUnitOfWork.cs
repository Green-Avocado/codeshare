using System;
using CodeShare.Core;

namespace CodeShare.Data
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<ProjectFile> ProjectFileRepository { get; }

        GenericRepository<ProjectOpening> ProjectOpeningRepository { get; }

        GenericRepository<ProjectRelease> ProjectReleaseRepository { get; }

        GenericRepository<Project> ProjectRepository { get; }

        GenericRepository<ProjectUser> ProjectUserRepository { get; }

        GenericRepository<ProjectUserRequest> ProjectUserRequestRepository { get; }

        void Save();

        GenericRepository<Tag> TagRepository { get; }

        GenericRepository<User> UserRepository { get; }
    }
}