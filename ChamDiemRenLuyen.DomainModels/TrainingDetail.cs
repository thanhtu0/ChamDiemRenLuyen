using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("TrainingDetail")]
    public class TrainingDetail
    {
        [Key]
        public int TrainingDetailId { get; set; }
        [Required]
        [MaxLength(50)]
        public string TrainingDetailName { get; set; }
        public bool IsProof { get; set; }
        public int MaxScore { get; set; }
        public string Location { get; set; }

        //Relationship
        public ICollection<TraniningDetailProof> TraniningDetailProofs { get; set; }
        public int TrainingContentId { get; set; }
        public TrainingContent TrainingContent { get; set; }
    }
}
