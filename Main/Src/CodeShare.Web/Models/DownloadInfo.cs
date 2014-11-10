using CodeShare.Core;
using System.Collections.Generic;

namespace CodeShare.Web.Models
{
    public class DownloadInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string QuickDescription { get; set; }

        public ProjectRelease CurrentRelease { get; set; }

        public List<ProjectRelease> Releases { get; set; }
    }
}