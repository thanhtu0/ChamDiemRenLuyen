using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class ProcessDetailRepository : Repository<ProcessDetail>, IProcessDetailRepository
    {
        private readonly TrainingScoingDBContext _context;
        public ProcessDetailRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
