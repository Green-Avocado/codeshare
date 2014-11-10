using CodeShare.Core;
using System;

namespace CodeShare.Data
{
    public class UnitOfWork : IDisposable, CodeShare.Data.IUnitOfWork
    {
        CodeShareEntities _context = new CodeShareEntities();
        GenericRepository<Project> _projectRepository;
        GenericRepository<ProjectFile> _projectFileRepository;
        GenericRepository<ProjectOpening> _projectOpeningRepository;
        GenericRepository<ProjectRelease> _projectReleaseRepository;
        GenericRepository<ProjectUser> _projectUserRepository;
        GenericRepository<ProjectUserRequest> _projectUserRequestRepository;
        GenericRepository<Tag> _tagRepository;
        GenericRepository<User> _userRepository;
        private bool _disposed = false;

        public GenericRepository<Project> ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new GenericRepository<Project>(_context);
                }

                return _projectRepository;
            }
        }

        public GenericRepository<ProjectFile> ProjectFileRepository
        {
            get
            {
                if (_projectFileRepository == null)
                {
                    _projectFileRepository = new GenericRepository<ProjectFile>(_context);
                }

                return _projectFileRepository;
            }
        }

        public GenericRepository<ProjectOpening> ProjectOpeningRepository
        {
            get
            {
                if (_projectOpeningRepository == null)
                {
                    _projectOpeningRepository = new GenericRepository<ProjectOpening>(_context);
                }

                return _projectOpeningRepository;
            }
        }

        public GenericRepository<ProjectRelease> ProjectReleaseRepository
        {
            get
            {
                if (_projectReleaseRepository == null)
                {
                    _projectReleaseRepository = new GenericRepository<ProjectRelease>(_context);
                }

                return _projectReleaseRepository;
            }
        }

        public GenericRepository<ProjectUser> ProjectUserRepository
        {
            get
            {
                if (_projectUserRepository == null)
                {
                    _projectUserRepository = new GenericRepository<ProjectUser>(_context);
                }

                return _projectUserRepository;
            }
        }

        public GenericRepository<ProjectUserRequest> ProjectUserRequestRepository
        {
            get
            {
                if (_projectUserRequestRepository == null)
                {
                    _projectUserRequestRepository = new GenericRepository<ProjectUserRequest>(_context);
                }

                return _projectUserRequestRepository;
            }
        }

        public GenericRepository<Tag> TagRepository
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new GenericRepository<Tag>(_context);
                }

                return _tagRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(_context);
                }

                return _userRepository;
            }
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}