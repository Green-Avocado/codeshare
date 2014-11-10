using System;
using System.Collections.Generic;
using System.Linq;
using CodeShare.Core;
using CodeShare.Data;
using CrossCutting.Core.Logging;
using CrossCutting.MainModule.IOC;

namespace CodeShare.Application
{
    public class ProjectService
    {
        public Project CreateProject(string name, string quickDescription, int userId)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    var project = unitOfWork.ProjectRepository.Search(p => p.Name == name).FirstOrDefault();
             
                    if (project == null)
                    {
                        project = new Project
                        {
                            Name = name,
                            QuickDescription = quickDescription,
                            CreationDate = DateTime.Now
                        };

                        unitOfWork.ProjectRepository.Insert(project);
                        unitOfWork.Save();

                        var user = unitOfWork.UserRepository.Get(userId);
                        var creator = new ProjectUser
                        {
                            IsActive = true,
                            JoinDate = DateTime.Now,
                            Role = ProjectUserRole.Administrator,
                            User = user
                        };

                        project.Creator = creator;
                        project.Members.Add(creator);
                        unitOfWork.ProjectRepository.Update(project);
                        unitOfWork.Save();

                        return project;
                    }
                    else
                    {
                        throw new ArgumentException("A project with the same name already exists", "name");
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.ProjectService.CreateProject", ex);
                throw ex;
            }
        }

        public Project GetProject(int id)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    var project = unitOfWork.ProjectRepository.Get(id);
                    return project;
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.ProjectService.GetProject", ex);
                return null;
            }
        }

        public List<Project> GetLatestProjects(int top)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    var projects = unitOfWork.ProjectRepository.SearchPaged(q => q.OrderByDescending(p => p.CreationDate), 0, top).Items.ToList();
                    return projects;
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.ProjectService.GetLatestProjects", ex);
                return null;
            }
        }

        public Project UpdateProjectInfo(int id, string quickDescription, string description, string logoUrl)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    var project = unitOfWork.ProjectRepository.Get(id);
                    project.QuickDescription = quickDescription;
                    project.Description = description;
                    project.LogoUrl = logoUrl;

                    unitOfWork.ProjectRepository.Update(project);
                    unitOfWork.Save();
                    return project;
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.ProjectService.UpdateProjectInfo", ex);
                throw;
            }
        }

        public void UpdateProjectSourceUrl(int id, string sourceUrl)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    var project = unitOfWork.ProjectRepository.Get(id);
                    project.SourceUrl = sourceUrl;

                    unitOfWork.ProjectRepository.Update(project);
                    unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.ProjectService.UpdateProjectSourceUrl", ex);
            }
        }

        public Project GetProjectWithReleases(int id)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    var project = unitOfWork.ProjectRepository.Search(p => p.Id == id, includeProperties: "Releases").FirstOrDefault();
                    return project;
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.ProjectService.GetProjectWithReleases", ex);
                return null;
            }
        }

        public bool IsProjectMember(int userId, int projectId)
        {
            try
            {
                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    var project = unitOfWork.ProjectRepository.Search(p => p.Id == projectId, includeProperties: "Members").FirstOrDefault();
                    return project.Members.Any(u => u.User.Id == userId);
                }
            }
            catch (Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.ProjectService.IsUserInProject", ex);
                return false;
            }
        }

        public PagedResult<Project> Search(string name, int page, int pageSize)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("name");
                }

                using (var unitOfWork = IocUnityContainer.Instance.Resolve<IUnitOfWork>())
                {
                    var paged = unitOfWork.ProjectRepository.SearchPaged(q => q.Where(p => p.Name.StartsWith(name)).OrderByDescending(p => p.Name), page, pageSize);
                    return paged;
                }
            }
            catch(Exception ex)
            {
                var logger = IocUnityContainer.Instance.Resolve<ILogManager>();
                logger.DefaultLogger.Error.Write("CodeShare.Application.ProjectService.Search", ex);
                return null;
            }
        }
    }
}