using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class ProofRepository : Repository<Proof>, IProofRepository
    {
        private readonly TrainingScoingDBContext _context;
        public ProofRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
