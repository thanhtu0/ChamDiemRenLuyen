using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface ILecturerRepository : IRepository<Lecturer>
    {
        Task<List<string>> GetUserRolesAsync(string lecturerCode); 
        Task<Lecturer> GetLecturerAsync(string lecturerCode);
    }
}
