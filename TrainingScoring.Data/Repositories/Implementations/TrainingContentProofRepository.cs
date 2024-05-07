using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class TrainingContentProofRepository :Repository<TrainingContentProof>, ITrainingContentProofRepository
    {
        private readonly TrainingScroingDBContext _context;
        public TrainingContentProofRepository(TrainingScroingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
