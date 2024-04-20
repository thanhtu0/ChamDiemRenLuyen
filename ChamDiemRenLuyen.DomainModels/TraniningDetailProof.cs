using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("TraniningDetailProof")]
    public class TraniningDetailProof
    {
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdatedAt { get; set; }

        //
        [ForeignKey("TrainingDetailId")]
        public int TrainingDetailId { get; set; }

        [ForeignKey("ProofId")]
        public int ProofId { get; set; }

        // Navigation properties
        public TrainingDetail TrainingDetail { get; set; }
        public Proof Proof { get; set; }
    }
}
