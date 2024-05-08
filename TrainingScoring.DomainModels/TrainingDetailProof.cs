using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.DomainModels.Interfaces;

namespace TrainingScoring.DomainModels
{
    [Table("TraniningDetailProofs")]
    public class TrainingDetailProof : ISoftDelete
    {
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }

        // Relationship
        [ForeignKey("TrainingDetailId")]
        public int TrainingDetailId { get; set; }

        [ForeignKey("ProofId")]
        public int ProofId { get; set; }

        public TrainingDetail TrainingDetail { get; set; }
        public Proof Proof { get; set; }
    }
}
