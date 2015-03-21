using System.Collections.Generic;
using CodeShare.Core;

namespace CodeShare.Application
{
    public interface IProjectService
    {
        Project CreateProject(string name, string quickDescription, int userId);
        
        List<Project> GetLatestProjects(int top);
        
        Project GetProject(int id);
        
        Project GetProjectWithReleases(int id);
        
        bool IsProjectMember(int userId, int projectId);
        
        PagedResult<Project> Search(string name, int page, int pageSize);
        
        Project UpdateProjectInfo(int id, string quickDescription, string description, string logoUrl);
        
        void UpdateProjectSourceUrl(int id, string sourceUrl);
    }
}