using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.DomainModels
{
    [Table("EvaluationForms")]
    public class EvaluationForm
    {
        [Key]
        public int EvalutionFormId { get; set; }

        [Required]
        [MaxLength(50)]
        public string EvaluationFormName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateStarted { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFinished { get; set; }

        // Relationship
        public int AcademicYearId { get; set; } // Foreign key referencing AcademicYearId in the associated table
        public AcademicYear AcademicYear { get; set; } // Navigation property representing the associated AcademicYear

        public ICollection<TrainingDirectory> TrainingDirectories { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
