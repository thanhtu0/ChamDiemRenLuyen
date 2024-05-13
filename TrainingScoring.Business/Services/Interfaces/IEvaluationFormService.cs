using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Business.Services.Utilities;
using TrainingScoring.Data.Repositories.Interfaces;
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
        #endregion
    }
}
