using System.ComponentModel;
using TrainingScoring.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace TrainingScoring.WebUI.Models
{
    public class TrainingDetailViewModel
    {
        public int EvaluationFormId { get; set; }
        public int TrainingDirectoryId { get; set; }
        public int TrainingContentId { get; set; }
        public int TrainingDetailId { get; set; }
        [DisplayName("Vị trí")]
        [Required(ErrorMessage = "{0} bắt buộc khác 0")]
        public int Order { get; set; }
        [DisplayName("Tên chi tiết rèn luyện")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string TrainingDetailName { get; set; }
        public bool IsProof { get; set; }
        public int MaxScore { get; set; }
        public TypeofScoreDetail TypeofScore { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        //
        public TrainingDetail ToTrainingDetail()
        {
            return new TrainingDetail
            {
                TrainingContentId = this.TrainingContentId,
                TrainingDetailId = this.TrainingDetailId,
                Order = this.Order,
                TrainingDetailName = this.TrainingDetailName,
                IsProof = this.IsProof,
                MaxScore = this.MaxScore,
                TypeofScore = this.TypeofScore,
                CreateAt = CreateAt,
                DeletedAt = DeletedAt
            };
        }
    }
}
