using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface IScoreRepository : IRepository<Score>
    {
        Task<List<Score>> GetByStudentIdAsync(int studentId);
        Task<Score> GetScoreAsync(int studentId, int academicYearId, int processId);
    }
}
