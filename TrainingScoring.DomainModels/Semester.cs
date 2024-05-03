using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.DomainModels
{
    [Table("Semesters")]
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }

        [Required]
        [MaxLength(10)]
        public string SemesterName { get; set; }
        //Relationship
        public ICollection<EvaluationForm> EvaluationForms { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
