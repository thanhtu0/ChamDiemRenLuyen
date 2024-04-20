using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Semester")]
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        [Required]
        public string SemesterName { get; set; }
        //
        public ICollection<EvaluationForm> EvaluationForms { get; set; }
    }
}
