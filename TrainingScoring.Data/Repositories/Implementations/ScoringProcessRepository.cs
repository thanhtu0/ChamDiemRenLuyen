using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class ScoringProcessRepository : Repository<ScoringProcess>, IScoringProcessRepository
    {
        private readonly TrainingScoingDBContext _context;
        public ScoringProcessRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
