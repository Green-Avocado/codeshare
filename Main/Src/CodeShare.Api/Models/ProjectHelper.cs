using CodeShare.Core;

namespace CodeShare.Api.Models
{
    public class ProjectHelper
    {
        public static ProjectInfo GetProjectInfoFromProject(Project project)
        {
            return new ProjectInfo
            {
                Id = project.Id,
                CreationDate = project.CreationDate,
                Description = project.Description,
                LogoUrl = project.LogoUrl,
                Name = project.Name,
                QuickDescription = project.QuickDescription,
                SourceUrl = project.SourceUrl
            };
        }
    }
}