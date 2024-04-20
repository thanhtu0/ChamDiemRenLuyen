using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("AcademicYear")]
    public class AcademicYear
    {
        [Key]   
        public int AcademicYearId { get; set; }
        [Required]
        public string AcademicYearName { get; set; }
        //
        public ICollection<EvaluationForm> EvaluationForms { get; set; }
    }
}
