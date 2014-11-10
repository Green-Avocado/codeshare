using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeShare.Core
{
    [Table("User")]
    public class User
    {
        public User()
        {
            Following = new HashSet<Project>();
            CreatorOf = new HashSet<Project>();
            AdministratorFor = new HashSet<Project>();
            ContributorFor = new HashSet<Project>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100), MinLength(3)]
        public string UserName { get; set; }

        [MaxLength(100), MinLength(3)]
        public string NickName { get; set; }

        [MaxLength(2083)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Avatar Url")]
        public string AvatarUrl { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        public virtual ICollection<Project> Following { get; set; }

        public virtual ICollection<Project> CreatorOf { get; set; }

        public virtual ICollection<Project> AdministratorFor { get; set; }
        
        public virtual ICollection<Project> ContributorFor { get; set; }
    }
}