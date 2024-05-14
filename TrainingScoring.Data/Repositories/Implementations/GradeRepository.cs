using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        private readonly TrainingScoingDBContext _context;
        public GradeRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
