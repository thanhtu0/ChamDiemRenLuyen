using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Lecturer")]
    public class Lecturer
    {
        [Key]
        public string LecturerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }

        //
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        //
        public ICollection<LecturerRoleAssignment> LecturerRoleAssignments { get; set; }
        //
        public ICollection<Advisor> Advisors { get; set; }
    }
}
