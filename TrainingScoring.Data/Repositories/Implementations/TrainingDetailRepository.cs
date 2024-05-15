using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class TrainingDetailRepository : Repository<TrainingDetail>, ITrainingDetailRepository
    {
        private readonly TrainingScoingDBContext _context;
        public TrainingDetailRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<TrainingDetail>> GetAllTrainingDetailByContentId(int id)
        {
            var details = await _context.TrainingDetails.Where(c => c.TrainingContentId == id).ToListAsync();
            return details;
        }

        public async Task<TrainingDetail> CreateAsync(TrainingDetail trainingDetail)
        {
            _context.Set<TrainingDetail>().Add(trainingDetail);
            await _context.SaveChangesAsync();
            return trainingDetail;
        }

        public async Task<TrainingDetail> UpdateAsync(TrainingDetail trainingDetail)
        {
            _context.Set<TrainingDetail>().Update(trainingDetail);
            await _context.SaveChangesAsync();
            return trainingDetail;
        }

        public async Task UpdateRangeAsync(IEnumerable<TrainingDetail> trainingDetails)
        {
            _context.Set<TrainingDetail>().UpdateRange(trainingDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<TrainingDetail> DeleteAsync(TrainingDetail trainingDetail)
        {
            _context.Set<TrainingDetail>().Remove(trainingDetail);
            await _context.SaveChangesAsync();
            return trainingDetail;
        }

        public async Task<int> GetMaxOrderAsync(int trainingContentId)
        {
            var existingDetails = await _context.TrainingDetails.Where(tc => tc.TrainingContentId == trainingContentId).ToListAsync();
            return existingDetails.Any() ? existingDetails.Max(c => c.Order) : 0;
        }

    }
}
