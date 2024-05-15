using Microsoft.EntityFrameworkCore;
using System.IO;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class TrainingContentRepository :Repository<TrainingContent>, ITrainingContentRepository
    {
        private readonly TrainingScoingDBContext _context;
        public TrainingContentRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TrainingContent>> GetAllTrainingContentByDirectoryId(int id)
        {
            var contents = await _context.TrainingContents.Where(c => c.TrainingDirectoryId == id).ToListAsync();
            return contents;
        }

        public async Task<TrainingContent> CreateAsync(TrainingContent trainingContent)
        {
            _context.Set<TrainingContent>().Add(trainingContent);
            await _context.SaveChangesAsync();
            return trainingContent;
        }

        public async Task<TrainingContent> UpdateAsync(TrainingContent trainingContent)
        {
            _context.Set<TrainingContent>().Update(trainingContent);
            await _context.SaveChangesAsync();
            return trainingContent;
        }

        public async Task UpdateRangeAsync(IEnumerable<TrainingContent> trainingContents)
        {
            _context.Set<TrainingContent>().UpdateRange(trainingContents);
            await _context.SaveChangesAsync();
        }

        public async Task<TrainingContent> DeleteAsync(TrainingContent trainingContent)
        {
            _context.Set<TrainingContent>().Remove(trainingContent);
            await _context.SaveChangesAsync();
            return trainingContent;
        }

        public async Task<int> GetMaxOrderAsync(int trainingDirectoryId)
        {
            var existingContents = await _context.TrainingContents.Where(tc => tc.TrainingDirectoryId == trainingDirectoryId).ToListAsync();
            return existingContents.Any() ? existingContents.Max(c => c.Order) : 0;
        }
    }
}
