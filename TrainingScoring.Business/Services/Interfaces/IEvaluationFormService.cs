using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public interface IEvaluationFormService 
    {
        // EvaluationForm   
        #region EvaluationForm
        Task<List<EvaluationForm>> GetAllEvaluationFormsAsync();
        Task<EvaluationForm> GetEvaluationFormByIdAsync(int id);
        Task<EvaluationForm> CreateEvaluationFormAsync(EvaluationForm evaluationForm);
        Task<EvaluationForm> UpdateEvaluationFormAsync(EvaluationForm evaluationForm);
        Task<EvaluationForm> DeleteEvaluationFormAsync(EvaluationForm evaluationForm);
        Task<bool> IsEvaluationFormExists(int id);
        Task<EvaluationForm> GetByCodeAsync(string code);
        Task<EvaluationForm> GetByNameAsync(string name);
        #endregion
    }
}
