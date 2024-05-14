using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class ScoreDetailRepository : Repository<ScoreDetail>, IScoreDetailRepository
    {
        private readonly TrainingScoingDBContext _context;
        public ScoreDetailRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
