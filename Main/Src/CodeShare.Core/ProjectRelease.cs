using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeShare.Core
{
    [Table("ProjectRelease")]
    public class ProjectRelease
    {
        public ProjectRelease()
        {
            Files = new HashSet<ProjectFile>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Download Count")]
        public int DownloadCount { get; set; }

        public virtual ProjectFile ReleaseFile { get; set; }

        public virtual ICollection<ProjectFile> Files { get; set; }
    }
}