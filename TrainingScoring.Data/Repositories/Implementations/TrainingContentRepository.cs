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

        public async Task<TrainingContent> CreateAsync(TrainingContent content)
        {
            _context.Set<TrainingContent>().Add(content);
            await _context.SaveChangesAsync();
            return content;
        }

        public async Task UpdateRangeAsync(List<TrainingContent> contents)
        {
            _context.Set<TrainingContent>().UpdateRange(contents);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TrainingContent content)
        {
            _context.Set<TrainingContent>().Remove(content);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetMaxOrderAsync()
        {
            return await _context.TrainingContents.MaxAsync(td => td.Order);
        }
    }
}
