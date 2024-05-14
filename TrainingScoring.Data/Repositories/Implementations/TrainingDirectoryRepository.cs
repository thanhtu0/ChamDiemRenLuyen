using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class TrainingDirectoryRepository :Repository<TrainingDirectory>, ITrainingDirectoryRepository
    {
        private readonly TrainingScoingDBContext _context;
        public TrainingDirectoryRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TrainingDirectory>> GetAllTrainingDirectoryByEFormId(int id)
        {
            var directories = await _context.TrainingDirectories.Where(t => t.EvaluationFormId == id).ToListAsync();
            return directories;
        }

        public async Task<TrainingDirectory> CreateAsync(TrainingDirectory directory)
        {
            _context.Set<TrainingDirectory>().Add(directory);
            await _context.SaveChangesAsync();
            return directory;
        }

        public async Task UpdateRangeAsync(List<TrainingDirectory> directories)
        {
            _context.Set<TrainingDirectory>().UpdateRange(directories);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TrainingDirectory directory)
        {
            _context.Set<TrainingDirectory>().Remove(directory);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetMaxOrderAsync()
        {
            return await _context.TrainingDirectories.MaxAsync(td => td.Order);
        }
    }
}
