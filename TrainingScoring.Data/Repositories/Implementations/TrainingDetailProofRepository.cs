using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class TrainingDetailProofRepository :Repository<TrainingDetailProof>, ITrainingDetailProofRepository
    {
        private readonly TrainingScoingDBContext _context;
        public TrainingDetailProofRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
