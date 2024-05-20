using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("ScoreDetails")]
    public class ScoreDetail
    {
        [Key]
        public int ScoreDetailId { get; set; }

        public int ScoreDetailValue { get; set; }
        public int ScoreDetailEvalution { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ScoreDetailDate { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
