using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("StudentClassCommittee")]
    public class StudentClassCommittee
    {
        // 
        [ForeignKey("StudentId")]
        public string StudentId { get; set; }

        [ForeignKey("ClassCommitteeId")]
        public int ClassCommitteeId { get; set; }

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual ClassCommittee ClassCommittee { get; set; }

    }
}
