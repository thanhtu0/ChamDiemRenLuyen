using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface ITrainingDetailRepository : IRepository<TrainingDetail>
    {
        public Task<List<TrainingDetail>> GetAllTrainingDetailByContentId(int id);

        Task<TrainingDetail> CreateAsync(TrainingDetail trainingDetail);
        Task<TrainingDetail> UpdateAsync(TrainingDetail trainingDetail);
        Task UpdateRangeAsync(IEnumerable<TrainingDetail> trainingDetails);
        Task<TrainingDetail> DeleteAsync(TrainingDetail trainingDetail);
        Task<int> GetMaxOrderAsync(int trainingContentId);
    }
}
