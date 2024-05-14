using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("Majors")]
    public class Major
    {
        [Key]
        public int MajorId { get; set; }
        [Required]
        [MaxLength(10)]
        public string MajorCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string MajorName { get; set; }

        //Relationship
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
