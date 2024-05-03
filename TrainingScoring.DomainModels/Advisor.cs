using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.DomainModels
{
    [Table("Advisors")]
    public class Advisor
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartYear { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndYear { get; set; }

        // Foreign key referencing LecturerId in the associated table
        [ForeignKey("LecturerId")]
        public string LecturerId { get; set; }
        // Foreign key referencing GradeId in the associated table
        [ForeignKey("GradeId")]
        public int GradeId { get; set; }

        // Relationship 
        public Lecturer Lecturer { get; set; }
        public Grade Grade { get; set; }
    }
}
