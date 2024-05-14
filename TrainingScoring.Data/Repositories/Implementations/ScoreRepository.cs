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
    }
}
