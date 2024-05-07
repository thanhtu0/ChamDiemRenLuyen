using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class ScoreDetailRepository : Repository<ScoreDetail>, IScoreDetailRepository
    {
        private readonly TrainingScroingDBContext _context;
        public ScoreDetailRepository(TrainingScroingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
