namespace CodeShare.Data
{
    using CodeShare.Core;
    using System.Data.Entity;

    public class CodeShareEntities : DbContext, ICodeShareEntities
    {
        public CodeShareEntities() : base("name=CodeShareEntities")
        {
        }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<ProjectFile> ProjectFiles { get; set; }

        public virtual DbSet<ProjectOpening> ProjectOpenings { get; set; }

        public virtual DbSet<ProjectRelease> ProjectReleases { get; set; }

        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }

        public virtual DbSet<ProjectUserRequest> ProjectUserRequests { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public EntityState GetState(object entity)
        {
            return Entry(entity).State;
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public DbSet<T> GetSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}