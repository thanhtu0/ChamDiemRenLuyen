using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly TrainingScoingDBContext _context;
        public RoleRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
