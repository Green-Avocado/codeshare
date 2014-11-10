using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeShare.Core
{
    [Table("ProjectUserRequest")]
    public class ProjectUserRequest
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MaxLength(140)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }


        public virtual ProjectOpening RelatedOpening { get; set; }
    }
}