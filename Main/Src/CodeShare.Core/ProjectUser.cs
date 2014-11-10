using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeShare.Core
{
    [Table("ProjectUser")]
    public class ProjectUser
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        public virtual ProjectUserRole Role { get; set; }
    }
}