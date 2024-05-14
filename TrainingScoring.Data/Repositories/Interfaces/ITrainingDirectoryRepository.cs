using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface ITrainingDirectoryRepository : IRepository<TrainingDirectory>
    {
        Task<List<TrainingDirectory>> GetAllTrainingDirectoryByEFormId(int id);

        Task<TrainingDirectory> CreateAsync(TrainingDirectory directory);

        Task UpdateRangeAsync(List<TrainingDirectory> directories);

        Task DeleteAsync(TrainingDirectory directory);

        Task<int> GetMaxOrderAsync();
    }
}
