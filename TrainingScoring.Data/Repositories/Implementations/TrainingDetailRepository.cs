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
    }
}
