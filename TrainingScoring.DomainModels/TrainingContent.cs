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
    [Table("TrainingContents")]
    public class TrainingContent : ISoftDelete
    {
        [Key]
        public int TrainingContentId { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [MaxLength(300)]
        public string TrainingContentName { get; set; }
        public bool IsProof {  get; set; }
        public int MaxScore { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }

        //Relationship
        public ICollection<TrainingContentProof> TrainingContentProofs { get; set; }
        public ICollection<TrainingDetail> TrainingDetails { get; set; }
        public int TrainingDirectoryId { get; set; }
        public TrainingDirectory TrainingDirectory { get; set; }
    }
}
