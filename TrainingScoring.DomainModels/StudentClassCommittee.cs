using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.DomainModels
{
    [Table("StudentClassCommittees")]
    public class StudentClassCommittee
    {
        // Foreign key referencing
        [ForeignKey("StudentId")]
        public string StudentId { get; set; }

        [ForeignKey("ClassCommitteeId")]
        public int ClassCommitteeId { get; set; }

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual ClassCommittee ClassCommittee { get; set; }

    }
}
