using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interface
{
    public interface IProofRepository :   IRepository<Proof>,
                                            IRepository<TrainingContentProof>,
                                            IRepository<TrainingDetailProof>
    {
    }
}
