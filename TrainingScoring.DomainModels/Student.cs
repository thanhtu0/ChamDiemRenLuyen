using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    public enum StudentGender
    {
        Male = 0,       // 0
        Female = 1      // 1
    }
    public enum Classmittee
    {
        Student = 0,
        Class_Monitor = 1,  
        Vice_Monitor = 2,  
        Secretary = 3    
    }

    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(20)]
        public string StudentCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public Classmittee IsClassmittee { get; set; }
        [Required]  
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Hometown { get; set; }
        public string Permanentaddress { get; set; }
        public string CitizenIdentificationNumber { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateofIssueofCitizenIdentificationCard { get; set; }
        public string Ethnicity { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        [Required]
        public StudentGender Gender { get; set; }

        public string? Photo { get; set; }

        public string Province { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //
        [ForeignKey("GradeId")]
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        //
        public ICollection<Score> Scores { get; set; }
        public ICollection<StudentScoreContent> StudentScoreContents { get; set; }
        public ICollection<StudentScoreDetail> StudentScoreDetails { get; set; }

    }
}
