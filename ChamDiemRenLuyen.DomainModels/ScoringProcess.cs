using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("ScoringProcess")]
    public class ScoringProcess
    {
        [Key]
        public int ProcessId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProcessName { get; set; }

        //Relationship
        public virtual ICollection<ProcessDetail> ProcessDetail { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
