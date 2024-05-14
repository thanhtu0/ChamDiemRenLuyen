using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface IEvaluationFormRepository : IRepository<EvaluationForm>
    {
        Task<EvaluationForm> CreateAsync(EvaluationForm evaluationForm);
        Task<EvaluationForm> GetByCodeAsync(string code);
        Task<EvaluationForm> GetByNameAsync(string name);

    }

}
