using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("ScoreDetail")]
    public class ScoreDetail
    {
        [Key]
        public int ScoreDetailId { get; set; }
        [Required]
        public int ScoreDetailValue { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ScoreDetailDate { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
