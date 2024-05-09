using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public interface ITrainingDirectoryService
    {

        #region TrainingDirectory
        Task<List<TrainingDirectory>> GetTrainingDirectoriesAsync();
        Task<TrainingDirectory> GetTrainingDirectoryByIdAsync(int id);
        Task<TrainingDirectory> CreateTrainingDirectoryAsync(TrainingDirectory trainingDirectory);
        Task<TrainingDirectory> UpdateTrainingDirectoryAsync(TrainingDirectory trainingDirectory);
        Task<TrainingDirectory> DeleteTrainingDirectoryAsync(TrainingDirectory trainingDirectory);
        #endregion
    }
}
