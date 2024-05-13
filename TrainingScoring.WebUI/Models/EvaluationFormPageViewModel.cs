namespace TrainingScoring.WebUI.Models
{
    public class EvaluationFormPageViewModel
    {
        public int EvaluationFormId { get; set; }
        public string EvvaluationFormCode { get; set; }
        public string EvaluationFormName { get; set; }
        public IEnumerable<EvaluationFormDetailsViewModel> EvaluationForms { get; set; }
    }
}
