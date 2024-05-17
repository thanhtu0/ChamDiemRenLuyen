using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly TrainingScoingDBContext _context;
        public StudentRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentByCodeAsync(string studentCode)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.StudentCode == studentCode);
        }
    }
}
