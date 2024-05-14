using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class LecturerRoleAssignmentRepository : Repository<LecturerRoleAssignment>, ILecturerRoleAssignmentRepository
    {
        private readonly TrainingScoingDBContext _context;
        public LecturerRoleAssignmentRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
