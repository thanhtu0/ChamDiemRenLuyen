using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("Scores")]
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }

        //Relationship
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("ScoringProcessId")]
        public int ProcessId { get; set; }
        public virtual ScoringProcess ScoringProcess { get; set; }

        [ForeignKey("ScoreDetailId")]
        public int ScoreDetailId {  get; set; }
        public virtual ScoreDetail ScoreDetail { get; set; }

        [ForeignKey("EvaluationFormId")]
        public int EvalutionFormId { get; set; }
        public virtual EvaluationForm EvaluationForm { get; set; }

        [ForeignKey("AcademicYearId")]
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
