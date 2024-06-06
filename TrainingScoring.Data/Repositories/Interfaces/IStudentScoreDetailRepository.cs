using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface IStudentScoreDetailRepository : IRepository<StudentScoreDetail>
    {
        Task<StudentScoreDetail> GetStudentScore(int studentId, int detailId);
        Task<List<StudentScoreDetail>> GetByIdAsync(int studentId);
    }
}
