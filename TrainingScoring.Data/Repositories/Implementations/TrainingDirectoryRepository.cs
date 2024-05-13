using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class TrainingDirectoryRepository :Repository<TrainingDirectory>, ITrainingDirectoryRepository
    {
        private readonly TrainingScoingDBContext _context;
        public TrainingDirectoryRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
