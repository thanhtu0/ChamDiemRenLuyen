using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface ITrainingDetailRepository : IRepository<TrainingDetail>
    {
        public Task<List<TrainingDetail>> GetAllTrainingDetailByContentId(int id);
    }
}
