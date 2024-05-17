using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface IStudentRepository :IRepository<Student>
    {
        Task<Student> GetStudentByCodeAsync(string studentCode);
    }
}
