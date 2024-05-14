using TrainingScoring.DomainModels;

namespace TrainingScoring.WebUI.Models
{
    public class TrainingContentViewModel
    {
        public int TrainingDirectoryId { get; set; }
        public int TrainingContentId { get; set; }
        public int Order { get; set; }
        public string TrainingContentName { get; set; }
        public bool IsProof { get; set; }
        public int MaxScore { get; set; }
        public TypeofScoreContent TypeofScore { get; set; }
        public IEnumerable<TrainingDetail> TrainingDetails { get; set; }
        // Phương thức chuyển đổi từ ViewModel sang Domain Model
        public TrainingContent ToTrainingContent()
        {
            return new TrainingContent
            {
                TrainingDirectoryId = this.TrainingDirectoryId,
                TrainingContentId = this.TrainingContentId,
                Order = this.Order,
                TrainingContentName = this.TrainingContentName,
                MaxScore = this.MaxScore,
                TypeofScore = this.TypeofScore
            };
        }
    }
}
