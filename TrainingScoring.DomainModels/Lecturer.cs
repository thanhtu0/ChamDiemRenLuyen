using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    public enum LecturerGender
    {
        Male = 0,  
        Female = 1   
    }
    [Table("Lecturers")]
    public class Lecturer
    {
        [Key]
        public int LecturerId { get; set; }
        [Required]
        [MaxLength(20)]
        public string LecturerCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public LecturerGender Gender { get; set; }

        public string? Photo { get; set; }

        public string Province { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Relationship 
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public ICollection<LecturerRoleAssignment> LecturerRoleAssignments { get; set; }
        public ICollection<GradeLecturerAssignment> GradeLecturerAssignments { get; set; }
    }
}
