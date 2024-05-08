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
    [Table("TrainingContentProofs")]
    public class TrainingContentProof : ISoftDelete
    {
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }
        //Relationship
        [ForeignKey("TrainingContentId")]
        public int TrainingContentId { get; set; }

        [ForeignKey("ProofId")]
        public int ProofId { get; set; }

        public TrainingContent TrainingContent  { get; set; }
        public Proof Proof { get; set; }
    }
}
