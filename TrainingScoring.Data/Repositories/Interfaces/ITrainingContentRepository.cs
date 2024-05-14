using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface ITrainingContentRepository :IRepository<TrainingContent>
    {
        Task<List<TrainingContent>> GetAllTrainingContentByDirectoryId(int id);

        Task<TrainingContent> CreateAsync(TrainingContent content);

        Task UpdateRangeAsync(List<TrainingContent> contents);

        Task DeleteAsync(TrainingContent content);

        Task<int> GetMaxOrderAsync();
    }
}
