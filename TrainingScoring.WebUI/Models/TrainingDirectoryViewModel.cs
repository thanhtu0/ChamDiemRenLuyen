
using TrainingScoring.DomainModels;

namespace TrainingScoring.WebUI.Models
{
    public class TrainingDirectoryViewModel
    {
        public int EvaluationFormId { get; set; }
        public int TrainingDirectoryId { get; set; }
        public int Order { get; set; }
        public string TrainingDirectoryName { get; set; }
        public int MaxScore { get; set; }
        public IEnumerable<TrainingContent> TrainingContents { get; set; }

        // Phương thức chuyển đổi từ ViewModel sang Domain Model
        public TrainingDirectory ToTrainingDirectory()
        {
            return new TrainingDirectory
            {
                EvaluationFormId = this.EvaluationFormId,
                TrainingDirectoryId = this.TrainingDirectoryId,
                Order = this.Order,
                TrainingDirectoryName = this.TrainingDirectoryName,
                MaxScore = this.MaxScore
            };
        }
    }
}
