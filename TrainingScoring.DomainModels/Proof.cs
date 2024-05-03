using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.DomainModels
{
    [Table("Proofs")]
    public class Proof
    {
        [Key]
        public int ProofId { get; set; }

        [Required]
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public long FileSizeByte { get; set; }

        //Relationship
        public TrainingContentProof TrainingContentProofs { get; set; }
        public TrainingDetailProof TraniningDetailProofs { get; set; }
    }
}
