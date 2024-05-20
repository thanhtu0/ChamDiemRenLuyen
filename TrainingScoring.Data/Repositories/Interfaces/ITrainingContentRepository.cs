using System.Threading.Tasks;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface ITrainingContentRepository :IRepository<TrainingContent>
    {
        Task<List<TrainingContent>> GetAllTrainingContentByDirectoryId(int id);

        Task<TrainingContent> CreateAsync(TrainingContent trainingContent);
        Task<TrainingContent> UpdateAsync(TrainingContent trainingContent);
        Task UpdateRangeAsync(IEnumerable<TrainingContent> trainingContents);
        Task<TrainingContent> DeleteAsync(TrainingContent trainingContent);
        Task<int> GetMaxOrderAsync(int trainingDirectoryId);
        Task<bool> IsNameDuplicateAsync(int trainingContentId, int trainingDirectoryId, string trainingContentName);
    }
}
