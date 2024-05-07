using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class EvaluationFormRepository : Repository<EvaluationForm>, IEvaluationFormRepository
    {
        private readonly TrainingScroingDBContext _context;
        public EvaluationFormRepository(TrainingScroingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
