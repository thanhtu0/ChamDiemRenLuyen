using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.DomainModels
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        //
        [ForeignKey("GradeId")]
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        //
        public virtual ICollection<StudentClassCommittee> StudentClassCommittees { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
