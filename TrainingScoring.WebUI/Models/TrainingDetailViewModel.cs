
namespace TrainingScoring.WebUI.Models
{
    public class TrainingDetailViewModel
    {
        public int TrainingDetailId { get; set; }
        public int Order { get; set; }
        public string TrainingDetailName { get; set; }
        public bool IsProof { get; set; }
        public int MaxScore { get; set; }
    }
}
