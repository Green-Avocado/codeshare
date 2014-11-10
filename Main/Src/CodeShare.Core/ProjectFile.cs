using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeShare.Core
{
    [Table("ProjectFile")]
    public class ProjectFile
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "File Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(2083)]
        [DataType(DataType.Url)]
        [Display(Name = "File Location")]
        public string Url { get; set; }
    }
}