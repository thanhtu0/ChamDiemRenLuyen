using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class ScoreRepository : Repository<Score>, IScoreRepository
    {
        private readonly TrainingScoingDBContext _context;
        public ScoreRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Score>> GetByStudentIdAsync(int studentId)
        {
            return await _context.Scores.Where(s => s.StudentId == studentId).ToListAsync();
        }

        public async Task<Score> GetScoreAsync(int studentId, int academicYearId, int processId)
        {
            return await _context.Scores
                                 .FirstOrDefaultAsync(s => s.StudentId == studentId && s.AcademicYearId == academicYearId && s.Process.ProcessId == processId);
        }
    }
}
