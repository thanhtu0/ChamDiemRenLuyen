using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public interface ITrainingContentService 
    {
        // TrainingContent
        #region TrainingContent
        Task<List<TrainingContent>> GetAllTrainingContentsAsync();
        Task<TrainingContent> GetTrainingContentByIdAsync(int id);
        Task<List<TrainingContent>> GetAllTrainingContentByDirectoryId(int id);
        Task<TrainingContent> CreateTrainingContentAsync(TrainingContent trainingContent);
        Task<TrainingContent> UpdateTrainingContentAsync(TrainingContent trainingContent);
        Task<TrainingContent> DeleteTrainingContentAsync(TrainingContent trainingContent);
        // Check Order and AdjustOrder
        Task<int> GetMaxOrderAsync();
        Task<bool> IsOrderOrNameDuplicateAsync(int trainingDirectoryId, int order, string name);
        Task AdjustOrdersAsync(int trainingDirectoryId, int newOrder);
        Task AdjustOrdersAfterDeletionAsync(int trainingDirectoryId);
        #endregion
    }
}
