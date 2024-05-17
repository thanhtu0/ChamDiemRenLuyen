using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CourseCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }

        [Required]
        [MaxLength(10)]
        public string StartYear { get; set; }

        [Required]
        [MaxLength(10)]
        public string EndYear { get; set; }

        //Relationship
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
