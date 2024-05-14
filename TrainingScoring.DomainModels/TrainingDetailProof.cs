using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("TraniningDetailProofs")]
    public class TrainingDetailProof 
    {
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
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
