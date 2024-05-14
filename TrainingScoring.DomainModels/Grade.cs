using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("Grades")]
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        [Required]
        [MaxLength(20)]
        public string GradeCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string GradeName { get; set; }

        [Required]
        public int NumberOfPupils { get; set; }

        // Relationship with Department
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        //Relationship with Course
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        // Relationship with Major
        public int MajorId { get; set; }
        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }

        // Relationship
        public virtual ICollection<Student> Students { get; set; }
        public ICollection<GradeLecturerAssignment> GradeLecturerAssignments { get; set; }
    }   
}
