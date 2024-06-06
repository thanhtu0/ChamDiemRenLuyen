using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class StudentScoreContentRepository : Repository<StudentScoreContent>, IStudentScoreContentRepository
    {
        private readonly TrainingScoingDBContext _context;

        public StudentScoreContentRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<StudentScoreContent> GetStudentScore(int studentId, int contentId)
        {
            return await _context.StudentScoreContents.FirstOrDefaultAsync(s => s.StudentId == studentId && s.TrainingContentId == contentId);
        }

        public async Task<List<StudentScoreContent>> GetByIdAsync(int studentId)
        {
            return await _context.StudentScoreContents.Where(s => s.StudentId == studentId).ToListAsync();
        }
    }
}
