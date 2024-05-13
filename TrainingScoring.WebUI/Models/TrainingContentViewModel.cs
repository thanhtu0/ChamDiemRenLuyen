using TrainingScoring.DomainModels;

namespace TrainingScoring.WebUI.Models
{
    public class TrainingContentViewModel
    {
        public int TrainingContentId { get; set; }
        public int Order { get; set; }
        public string TrainingContentName { get; set; }
        public bool IsProof { get; set; }
        public int MaxScore { get; set; }
        public IEnumerable<TrainingDetail> TrainingDetails { get; set; }
    }
}
