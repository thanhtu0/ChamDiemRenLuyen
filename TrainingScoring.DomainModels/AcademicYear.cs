using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    public enum SemesterType
    {
        First = 1,  
        Second = 2, 
    }
    [Table("AcademicYears")]
    public class AcademicYear
    {
        [Key]   
        public int AcademicYearId { get; set; }
        [Required]
        public string SemesterCode { get; set; }
        [Required]
        [StringLength(50)]
        public string AcademicYearName { get; set; }
        public SemesterType Semester { get; set; }
        // Relationship
        public ICollection<EvaluationForm> EvaluationForms { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
