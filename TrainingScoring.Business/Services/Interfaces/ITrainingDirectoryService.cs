using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public interface ITrainingDirectoryService
    {

        #region TrainingDirectory
        Task<List<TrainingDirectory>> GetAllTrainingDirectoriesAsync();
        Task<TrainingDirectory> GetTrainingDirectoryByIdAsync(int id);
        Task<List<TrainingDirectory>> GetAllTrainingDirectoryByEFormId(int id);
        Task<TrainingDirectory> CreateTrainingDirectoryAsync(TrainingDirectory trainingDirectory);
        Task<TrainingDirectory> UpdateTrainingDirectoryAsync(TrainingDirectory trainingDirectory);
        Task<TrainingDirectory> DeleteTrainingDirectoryAsync(TrainingDirectory trainingDirectory);
        // Check Order and AdjustOrder
        Task<int> GetMaxOrderAsync();
        Task<bool> IsOrderOrNameDuplicateAsync(int evaluationFormId, int order, string name);
        Task<bool> IsNameDuplicateAsync(int trainingDirectoryId, int evaluationFormId, string name);
        Task AdjustOrdersAsync(int evaluationFormId, int newOrder);
        Task AdjustOrdersAfterDeletionAsync(int evaluationFormId);
        #endregion
    }
}
