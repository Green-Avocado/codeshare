using System;

namespace CodeShare.Api.Models
{
    public class ProjectInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string QuickDescription { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public string SourceUrl { get; set; }

        public DateTime CreationDate { get; set; }
    }
}