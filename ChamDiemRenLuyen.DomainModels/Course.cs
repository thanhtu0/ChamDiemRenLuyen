using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartYear { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndYear { get; set; }
        //
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
