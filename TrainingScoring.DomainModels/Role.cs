using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }
        [Required]
        [MaxLength(50)]
        public string RoleDescription { get; set; }

        // Relationship
        public ICollection<LecturerRoleAssignment> LecturerRoleAssignments { get; set; }
        public virtual ICollection<ProcessDetail> ProcessDetail { get; set; }    
    }
}
