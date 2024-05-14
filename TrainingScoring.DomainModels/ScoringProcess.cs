using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("ScoringProcesses")]
    public class ScoringProcess
    {
        [Key]
        public int ProcessId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProcessName { get; set; }

        //Relationship
        public virtual ICollection<ProcessDetail> ProcessDetail { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
