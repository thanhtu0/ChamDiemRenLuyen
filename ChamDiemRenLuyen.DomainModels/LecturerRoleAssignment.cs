using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("LecturerRoleAssignment")]
    public class LecturerRoleAssignment
    {
        // 
        [ForeignKey("LecturerId")]
        public string LecturerId { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        // Navigation properties
        public Lecturer Lecturer { get; set; }
        public Role Role { get; set; }
    }
}
