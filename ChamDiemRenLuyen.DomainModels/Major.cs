using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Major")]
    public class Major
    {
        [Key]
        public int MajorId { get; set; }
        [Required]
        [MaxLength(50)]
        public string MajorName { get; set; }

        //
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
