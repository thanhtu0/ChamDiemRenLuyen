using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public interface ITrainingContentService 
    {
        // TrainingContent
        #region TrainingContent
        Task<List<TrainingContent>> GetAllTrainingContentsAsync();
        Task<TrainingContent> GetTrainingContentsByIdAsync(int id);
        Task<TrainingContent> CreateTrainingContentsAsync(TrainingContent trainingContent);
        Task<TrainingContent> UpdateTrainingContentsAsync(TrainingContent trainingContent);
        Task<TrainingContent> DeleteTrainingContentsAsync(TrainingContent trainingContent);
        #endregion
    }
}
