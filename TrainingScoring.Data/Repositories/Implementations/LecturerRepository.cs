using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class LecturerRepository : Repository<Lecturer>, ILecturerRepository
    {
        private readonly TrainingScoingDBContext _context;
        public LecturerRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
