using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }

        //
        public ICollection<LecturerRoleAssignment> LecturerRoleAssignments { get; set; }
    }
}
