using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("StudentScoreContents")]
    public class StudentScoreContent
    {
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        [ForeignKey("TrainingContentId")]
        public int TrainingContentId { get; set; }

        public TrainingContent TrainingContent { get; set; }
        public Student Student { get; set; }
        public int? Score { get; set; }
        public bool? IsChecked { get; set; }
    }
}
