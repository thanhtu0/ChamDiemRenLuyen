using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.DomainModels.Interfaces;

namespace TrainingScoring.DomainModels
{
    [Table("TrainingDirectories")]
    public class TrainingDirectory : ISoftDelete
    {
        [Key]
        public int TrainingDirectoryId { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [MaxLength(300)]
        public string TrainingDirectoryName { get; set; }
        [Required]
        public int MaxScore {  get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }

        //Relationship
        public ICollection<TrainingContent> TrainingContents { get; set; }

        public int EvaluationFormId { get; set; }
        public EvaluationForm EvaluationForm { get; set; }
        
    }
}
