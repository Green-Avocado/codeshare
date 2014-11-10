using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeShare.Core
{
    [Table("Project")]
    public class Project
    {
        public Project()
        {
            Likes = new HashSet<User>();
            Followers = new HashSet<User>();
            Members = new HashSet<ProjectUser>();
            MemberRequests = new HashSet<ProjectUserRequest>();
            Openings = new HashSet<ProjectOpening>();
            Tags = new HashSet<Tag>();
            Releases = new HashSet<ProjectRelease>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100), MinLength(3)]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(140), MinLength(5)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Quick Description")]
        public string QuickDescription { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [MaxLength(2083)]
        [Display(Name = "Logo Url")]
        [DataType(DataType.ImageUrl)]
        public string LogoUrl { get; set; }

        [MaxLength(2083)]
        [DataType(DataType.Url)]
        [Display(Name = "Source Url")]
        public string SourceUrl { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        public virtual ICollection<User> Likes { get; set; }

        public virtual ICollection<User> Followers { get; set; }

        public virtual ProjectUser Creator { get; set; }

        public virtual ICollection<ProjectUser> Members { get; set; }

        public virtual ICollection<ProjectUserRequest> MemberRequests { get; set; }

        public virtual ICollection<ProjectOpening> Openings { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<ProjectRelease> Releases { get; set; }
    }
}