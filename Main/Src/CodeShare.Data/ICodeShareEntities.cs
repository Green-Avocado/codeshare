using CodeShare.Core;
using System.Data.Entity;

namespace CodeShare.Data
{
    public interface ICodeShareEntities
    {
        DbSet<Project> Projects { get; set; }

        DbSet<ProjectFile> ProjectFiles { get; set; }

        DbSet<ProjectOpening> ProjectOpenings { get; set; }

        DbSet<ProjectRelease> ProjectReleases { get; set; }

        DbSet<ProjectUser> ProjectUsers { get; set; }

        DbSet<ProjectUserRequest> ProjectUserRequests { get; set; }

        DbSet<Tag> Tags { get; set; }

        DbSet<User> Users { get; set; }

        EntityState GetState(object entity);

        void SetModified(object entity);

        DbSet<T> GetSet<T>() where T : class;
    }
}