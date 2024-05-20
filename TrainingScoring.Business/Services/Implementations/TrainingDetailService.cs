using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data.Repositories.Implementations;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Implementations
{
    public class TrainingDetailService : ITrainingDetailService
    {
        private readonly ILogger<TrainingDetailService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ITrainingDetailRepository _trainingDetailRepository;

        public TrainingDetailService(ILogger<TrainingDetailService> logger, 
            IHttpContextAccessor httpContextAccessor, 
            ITrainingDetailRepository trainingDetailRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _trainingDetailRepository = trainingDetailRepository;
        }

        #region TrainingDetail
        public async Task<List<TrainingDetail>> GetAllTrainingDetailsAsync()
        {
            try
            {
                var trainingDetailRepository = await _trainingDetailRepository.GetAllAsync();
                if (trainingDetailRepository == null)
                {
                    throw new Exception("Không có Chi tiết rèn luyện nào!");
                }

                return trainingDetailRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<TrainingDetail> GetTrainingDetailByIdAsync(int id)
        {
            try
            {
                var trainingDetailRepository = await _trainingDetailRepository.GetByIdAsync(id);

                if (trainingDetailRepository == null)
                {
                    throw new Exception("Không có chi tiết rèn luyện cần tìm");
                }

                return trainingDetailRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TrainingDetail>> GetAllTrainingDetailByContentId(int id)
        {
            try
            {
                var trainingDetails = await _trainingDetailRepository.GetAllTrainingDetailByContentId(id);

                if (trainingDetails == null || !trainingDetails.Any())
                {
                    throw new Exception("Không có chi tiết rèn luyện nào cho nội dung này");
                }

                return trainingDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi: {ex.Message}");
                throw;
            }
        }

        public async Task<TrainingDetail> CreateTrainingDetailAsync(TrainingDetail trainingDetail)
        {
            try
            {
                var existingDetails = await _trainingDetailRepository.GetAllTrainingDetailByContentId(trainingDetail.TrainingContentId);

                var isNameDuplicate = existingDetails.Any(td => td.TrainingDetailName.Equals(trainingDetail.TrainingDetailName, StringComparison.OrdinalIgnoreCase));

                if (isNameDuplicate)
                {
                    throw new ApplicationException("Chi tiết rèn luyện đã tồn tại.Vui lòng nhập lại.");
                }

                int newIndex = existingDetails.Count;

                for (int i = 0; i < existingDetails.Count; i++)
                {
                    if (existingDetails[i].Order >= trainingDetail.Order)
                    {
                        newIndex = i;
                        break;
                    }
                }

                for (int i = newIndex; i < existingDetails.Count; i++)
                {
                    existingDetails[i].Order++;
                }

                existingDetails.Insert(newIndex, trainingDetail);

                await _trainingDetailRepository.UpdateRangeAsync(existingDetails);

                return trainingDetail;
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, $"Application Error: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw new ApplicationException("Error occurred while creating training content", ex);
            }
        }

        public async Task<TrainingDetail> UpdateTrainingDetailAsync(TrainingDetail trainingDetail)
        {
            try
            {
                var existingDetail = await _trainingDetailRepository.GetByIdAsync(trainingDetail.TrainingDetailId);
                if (existingDetail == null)
                {
                    throw new ArgumentException("Không có chi tiết rèn luyện.");
                }

                var existingDetails = await _trainingDetailRepository.GetAllTrainingDetailByContentId(trainingDetail.TrainingContentId);

                var isNameDuplicate = existingDetails.Any(tc => tc.TrainingDetailName.Equals(trainingDetail.TrainingDetailName, StringComparison.OrdinalIgnoreCase) && tc.TrainingDetailId != trainingDetail.TrainingDetailId);
                if (isNameDuplicate)
                {
                    throw new ApplicationException("Chi tiết rèn luyện đẫ tồn tại.");
                }

                if (existingDetail.Order != trainingDetail.Order)
                {
                    if (existingDetail.Order > trainingDetail.Order)
                    {
                        foreach (var detail in existingDetails.Where(td => td.Order >= trainingDetail.Order && td.Order < existingDetail.Order))
                        {
                            detail.Order++;
                        }
                    }
                    else
                    {
                        foreach (var content in existingDetails.Where(td => td.Order <= trainingDetail.Order && td.Order > existingDetail.Order))
                        {
                            content.Order--;
                        }
                    }
                }

                existingDetail.TrainingDetailName = trainingDetail.TrainingDetailName;
                existingDetail.IsProof = trainingDetail.IsProof;
                existingDetail.MaxScore = trainingDetail.MaxScore;
                existingDetail.TypeofScore = trainingDetail.TypeofScore;
                existingDetail.CreateAt = trainingDetail.CreateAt;
                existingDetail.DeletedAt = trainingDetail.DeletedAt;
                existingDetail.Order = trainingDetail.Order;

                return await _trainingDetailRepository.UpdateAsync(existingDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating training content: {ex.Message}");
                throw new ApplicationException("Error occurred while updating training content", ex);
            }
        }

        public async Task<TrainingDetail> DeleteTrainingDetailAsync(TrainingDetail trainingDetail)
        {
            try
            {
                if (trainingDetail == null)
                {
                    throw new ArgumentNullException(nameof(trainingDetail), "Chi tiết rèn luyện không được để trống.");
                }

                var existinDetail = await _trainingDetailRepository.GetByIdAsync(trainingDetail.TrainingDetailId);
                if (existinDetail == null)
                {
                    throw new ArgumentException("Không tìm thấy chi tiêt rèn luyện cần xóa.");
                }

                int contentId = existinDetail.TrainingContentId;

                await _trainingDetailRepository.DeleteAsync(existinDetail);

                await AdjustOrdersAfterDeletionAsync(contentId);

                return existinDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa nội dung đào tạo: {ex.Message}");
                throw;
            }
        }

        public async Task AdjustOrdersAfterDeletionAsync(int trainingContentId)
        {
            var details = await _trainingDetailRepository.GetAllTrainingDetailByContentId(trainingContentId);

            int order = 1;
            foreach (var detail in details.OrderBy(c => c.Order))
            {
                detail.Order = order++;
            }

            await _trainingDetailRepository.UpdateRangeAsync(details);
        }

        public async Task<int> GetMaxOrderAsync(int trainingContentId)
        {
            return await _trainingDetailRepository.GetMaxOrderAsync(trainingContentId);
        }

        public async Task<bool> IsNameDuplicateAsync(int trainingDetailId, int trainingContentId, string trainingDetailName)
        {
            var existingContents = await _trainingDetailRepository.GetAllTrainingDetailByContentId(trainingContentId);
            return existingContents.Any(tc => tc.TrainingDetailName.Equals(trainingDetailName, StringComparison.OrdinalIgnoreCase) && tc.TrainingDetailId != trainingDetailId);
        }
        #endregion
    }
}
