using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("LecturerRoleAssignments")]
    public class LecturerRoleAssignment
    {
        // Relationship
        [ForeignKey("LecturerId")]
        public int LecturerId { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public Lecturer Lecturer { get; set; }
        public Role Role { get; set; }
    }
}
