using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly TrainingScoingDBContext _context;
        public CourseRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
