using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.DomainModels
{
    [Table("GradeLecturerAssignments")]
    public class GradeLecturerAssignment
    {
        [ForeignKey("LecturerId")]
        public int LecturerId { get; set; }

        [ForeignKey("GradeId")]
        public int GradeId { get; set; }

        public Lecturer Lecturer { get; set; }
        public Grade Grade { get; set; } 
    }
}
