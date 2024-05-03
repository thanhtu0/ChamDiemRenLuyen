using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interface
{
    public interface IEvaluatioFormRepository :     IRepository<EvaluationForm>,
                                                    IRepository<TrainingDirectory>,
                                                    IRepository<TrainingContent>,
                                                    IRepository<TrainingDetail>
    {

    }
}
