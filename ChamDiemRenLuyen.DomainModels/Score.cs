using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Score")]
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }

        //Relationship
        [ForeignKey("StudentId")]
        public string StudentId { get; set; }
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

        [ForeignKey("SemesterId")]
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

    }
}
