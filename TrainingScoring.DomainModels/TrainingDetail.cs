using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    public enum TypeofScoreDetail
    {
        Radio = 0,
        CheckedBox = 1,
        Input = 2
    }

    [Table("TrainingDetails")]
    public class TrainingDetail 
    {
        [Key]
        public int TrainingDetailId { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [MaxLength(300)]
        public string TrainingDetailName { get; set; }
        public bool IsProof { get; set; }
        public int MaxScore { get; set; }
        public TypeofScoreDetail TypeofScore { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }

        //Relationship
        public ICollection<TrainingDetailProof> TraniningDetailProofs { get; set; }
        public ICollection<StudentScoreDetail> StudentScoreDetails { get; set; }

        public int TrainingContentId { get; set; }
        public TrainingContent TrainingContent { get; set; }
    }
}
