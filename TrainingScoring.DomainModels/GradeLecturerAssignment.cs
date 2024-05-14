using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("GradeLecturerAssignments")]
    public class GradeLecturerAssignment
    {
        [ForeignKey("LecturerId")]
        public int LecturerId { get; set; }

        [ForeignKey("GradeId")]
        public int GradeId { get; set; }

        public Lecturer Lecturer { get; set; }
        public Grade Grade { get; set; } 
    }
}
