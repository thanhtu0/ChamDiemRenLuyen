using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.DomainModels.Interfaces;

namespace TrainingScoring.DomainModels
{
    [Table("EvaluationForms")]
    public class EvaluationForm : ISoftDelete
    {
        [Key]
        public int EvalutionFormId { get; set; }
        [Required]
        public string EvalutionFormCode { get; set; }

        [Required]
        [MaxLength(150)]
        public string EvaluationFormName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreateAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }

        // Relationship
        public int AcademicYearId { get; set; } // Foreign key referencing AcademicYearId in the associated table
        public AcademicYear AcademicYear { get; set; } // Navigation property representing the associated AcademicYear

        public ICollection<TrainingDirectory> TrainingDirectories { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
