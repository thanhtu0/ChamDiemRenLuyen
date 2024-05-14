using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class GradeLecturerAssignmentRepository: Repository<GradeLecturerAssignment>, IGradeLecturerAssignmentRepository
    {
        private readonly TrainingScoingDBContext _context;
        public GradeLecturerAssignmentRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
