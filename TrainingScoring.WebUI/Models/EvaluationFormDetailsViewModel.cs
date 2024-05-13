using TrainingScoring.DomainModels;

namespace TrainingScoring.WebUI.Models
{
    public class EvaluationFormDetailsViewModel
    {
        public int EvaluationFormId { get; set; }
        public string EvvaluationFormCode { get; set; }
        public string EvaluationFormName { get; set; }
        public IEnumerable<TrainingDirectory> TrainingDirectories { get; set; }
        public IEnumerable<TrainingContent> TrainingContents { get; set; }
        public IEnumerable<TrainingDetail> TrainingDetails { get; set; }
    }
}
