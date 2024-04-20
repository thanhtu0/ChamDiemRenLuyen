using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Score")]
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        [Required]
        public int ScoreValue { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ScoreDate { get; set; }
    }
}
