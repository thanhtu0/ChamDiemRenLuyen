using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.DomainModels
{
    [Table("LecturerRoleAssignment")]
    public class LecturerRoleAssignment
    {
        // Relationship
        [ForeignKey("LecturerId")]
        public string LecturerId { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public Lecturer Lecturer { get; set; }
        public Role Role { get; set; }
    }
}
