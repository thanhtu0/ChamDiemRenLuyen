using System.ComponentModel;
using TrainingScoring.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace TrainingScoring.WebUI.Models
{
    public class TrainingDirectoryViewModel
    {
        //
        public int EvaluationFormId { get; set; }
        public int TrainingDirectoryId { get; set; }
        [DisplayName("Vị trí")]
        [Required(ErrorMessage = "{0} bắt buộc khác 0")]
        public int Order { get; set; }
        [DisplayName("Tên danh mục rèn luyện")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
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
