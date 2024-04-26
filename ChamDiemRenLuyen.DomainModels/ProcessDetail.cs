using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("ProcessDetail")]
    public class ProcessDetail
    {
        [Key]
        public int DetailId { get; set; }
        
        //Relationship
        [ForeignKey("ScoringProcess")]
        public int ProcessId { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public ScoringProcess ScoringProcess { get; set; }
        public Role Role { get; set; }
    }
}
