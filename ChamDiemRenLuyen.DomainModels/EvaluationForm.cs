using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("EvaluationForm")]
    public class EvaluationForm
    {
        [Key]
        public int EvalutionFormId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EvaluationFormName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateStarted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateFinished { get; set; }

        // 
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
        //
        public ICollection<TrainingDirectory> TrainingDirectories { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
