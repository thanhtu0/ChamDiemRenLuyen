using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public interface ITrainingDetailService
    {
        // TrainingDetail
        #region TrainingDetail
        Task<List<TrainingDetail>> GetAllTrainingDetailsAsync();
        Task<TrainingDetail> GetTrainingDetailsByIdAsync(int id);
        Task<TrainingDetail> CreateTrainingDetailsAsync(TrainingDetail trainingDetail);
        Task<TrainingDetail> UpdateTrainingDetailsAsync(TrainingDetail trainingDetail);
        Task<TrainingDetail> DeleteTrainingDetailsAsync(TrainingDetail trainingDetail);
        #endregion
    }
}
