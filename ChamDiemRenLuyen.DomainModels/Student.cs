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

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool Gender { get; set; }

        public string Province { get; set; }

        [DataType(DataType.EmailAddress)]
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
