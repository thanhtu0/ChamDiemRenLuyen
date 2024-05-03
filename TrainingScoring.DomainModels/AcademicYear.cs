using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.DomainModels
{
    [Table("AcademicYears")]
    public class AcademicYear
    {
        [Key]   
        public int AcademicYearId { get; set; }
        [Required]
        [StringLength(50)]
        public string AcademicYearName { get; set; }


        // Relationship
        public ICollection<EvaluationForm> EvaluationForms { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
