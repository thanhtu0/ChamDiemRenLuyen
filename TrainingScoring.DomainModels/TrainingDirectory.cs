using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.DomainModels
{
    [Table("TrainingDirectories")]
    public class TrainingDirectory
    {
        [Key]
        public int TrainingDirectoryId { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [MaxLength(50)]
        public string TrainingDirectoryName { get; set; }
        public int MaxScore {  get; set; }

        //Relationship
        public ICollection<TrainingContent> TrainingContents { get; set; }

        public int EvaluationFormId { get; set; }
        public EvaluationForm EvaluationForm { get; set; }
    }
}
