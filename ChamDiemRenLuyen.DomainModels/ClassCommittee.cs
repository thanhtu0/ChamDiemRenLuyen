using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("ClassCommittee")]
    public class ClassCommittee
    {
        [Key]
        public int ClassCommitteeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ClassCommitteeName { get; set; }

        //Relationship
        public virtual ICollection<StudentClassCommittee> StudentClassCommittees { get; set; }
    }
}
