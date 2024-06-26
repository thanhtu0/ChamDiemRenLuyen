﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScoring.DomainModels
{
    [Table("ProcessDetails")]
    public class ProcessDetail
    {
        [Key]
        public int DetailId { get; set; }
        
        //Relationship
        [ForeignKey("ScoringProcess")]
        public int ProcessId { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public ScoringProcess ScoringProcess { get; set; }
        public Role Role { get; set; }
    }
}
