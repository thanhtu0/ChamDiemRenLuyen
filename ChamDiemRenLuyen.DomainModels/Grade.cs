using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string GradeName { get; set; }
        public int NumberOfPupils { get; set; }

        //
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public int MajorId { get; set; }
        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }
        //
        public virtual ICollection<Student> Students { get; set; }
        //
        public ICollection<Advisor> Advisors { get; set; }
    }   
}
