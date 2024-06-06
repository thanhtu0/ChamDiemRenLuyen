using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface IStudentScoreContentRepository : IRepository<StudentScoreContent>
    {
        Task<StudentScoreContent> GetStudentScore(int studentId, int contentId);
        Task<List<StudentScoreContent>> GetByIdAsync(int studentId);
    }
}
