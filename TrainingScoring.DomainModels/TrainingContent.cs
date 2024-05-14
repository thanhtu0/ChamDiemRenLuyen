using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    public enum TypeofScoreContent
    {
        Radio = 0,
        CheckeBox = 1,
        Input = 2
    }

    [Table("TrainingContents")]
    public class TrainingContent 
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
        public TypeofScoreContent TypeofScore { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreateAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }

        //Relationship
        public ICollection<TrainingContentProof> TrainingContentProofs { get; set; }
        public ICollection<TrainingDetail> TrainingDetails { get; set; }
        public int TrainingDirectoryId { get; set; }
        public TrainingDirectory TrainingDirectory { get; set; }
    }
}
