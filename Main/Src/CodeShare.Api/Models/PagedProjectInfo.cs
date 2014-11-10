using System.Collections.Generic;

namespace CodeShare.Api.Models
{
    public class PagedProjectInfo
    {
        public IEnumerable<ProjectInfo> Items { get; set; }

        public int TotalCount { get; set; }
    }
}