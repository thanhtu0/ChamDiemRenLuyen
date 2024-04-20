using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Proof")]
    public class Proof
    {
        [Key]
        public int ProofId { get; set; }
        [Required]
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public long FileSizeByte { get; set; }

        //
        public ICollection<TrainingContentProof> TrainingContentProofs { get; set; }
        public ICollection<TraniningDetailProof> TraniningDetailProofs { get; set; }
    }
}
