using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public interface ITrainingDetailService
    {
        // TrainingDetail
        #region TrainingDetail
        Task<List<TrainingDetail>> GetAllTrainingDetailsAsync();
        Task<TrainingDetail> GetTrainingDetailByIdAsync(int id);
        Task<List<TrainingDetail>> GetAllTrainingDetailByContentId(int id);
        Task<TrainingDetail> CreateTrainingDetailAsync(TrainingDetail trainingDetail);
        Task<TrainingDetail> UpdateTrainingDetailAsync(TrainingDetail trainingDetail);
        Task<TrainingDetail> DeleteTrainingDetailAsync(TrainingDetail trainingDetail);

        // Check Order and AdjustOrder
        Task<int> GetMaxOrderAsync(int trainingContentId);
        Task AdjustOrdersAfterDeletionAsync(int trainingContentId);
        Task<bool> IsNameDuplicateAsync(int trainingDetailId, int trainingContentId, string trainingDetailName);
        #endregion
    }
}
