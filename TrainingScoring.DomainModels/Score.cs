using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    public enum Status
    {
        Complete = 0,
        Unfinished = 1
    }
    [Table("Scores")]
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        public int TotalScore { get; set; }
        public string Ranking { get; set; }
        public Status Status { get; set; }
        //Relationship
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("ProcessId")]
        public int ProcessId { get; set; }
        public virtual ScoringProcess Process { get; set; }

        [ForeignKey("EvaluationFormId")]
        public int EvalutionFormId { get; set; }
        public virtual EvaluationForm EvaluationForm { get; set; }

        [ForeignKey("AcademicYearId")]
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
