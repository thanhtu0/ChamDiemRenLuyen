using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class TrainingContentRepository :Repository<TrainingContent>, ITrainingContentRepository
    {
        private readonly TrainingScoingDBContext _context;
        public TrainingContentRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
