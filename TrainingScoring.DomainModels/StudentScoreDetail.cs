using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("StudentScoreDetails")]
    public class StudentScoreDetail
    {

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        [ForeignKey("TrainingDetailId")]
        public int TrainingDetailId { get; set; }

        public TrainingDetail TrainingDetail { get; set; }
        public Student Student { get; set; }
        public int? Score { get; set; }
        public bool? IsChecked { get; set; }
    }
}
