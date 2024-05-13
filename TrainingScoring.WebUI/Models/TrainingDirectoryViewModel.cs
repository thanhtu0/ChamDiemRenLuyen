
using TrainingScoring.DomainModels;

namespace TrainingScoring.WebUI.Models
{
    public class TrainingDirectoryViewModel
    {
        public int TrainingDirectoryId { get; set; }
        public int Order { get; set; }
        public string TrainingDirectoryName { get; set; }
        public int MaxScore { get; set; }
        public IEnumerable<TrainingContent> TrainingContents { get; set; }
    }
}
