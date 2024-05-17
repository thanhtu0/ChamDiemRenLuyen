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
                    throw new Exception("Không có chi tiết rèn luyện");
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
                    throw new Exception("Không có nội dung rèn luyện nào cho danh mục này");
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
                    throw new ApplicationException("Training Detail Name already exists.");
                }

                // Tìm vị trí thích hợp để chèn mới
                int newIndex = existingDetails.Count;

                for (int i = 0; i < existingDetails.Count; i++)
                {
                    if (existingDetails[i].Order >= trainingDetail.Order)
                    {
                        newIndex = i;
                        break;
                    }
                }

                // Điều chỉnh thứ tự của các training content sau newIndex
                for (int i = newIndex; i < existingDetails.Count; i++)
                {
                    existingDetails[i].Order++;
                }

                // Thêm mới training content vào vị trí đã chọn
                existingDetails.Insert(newIndex, trainingDetail);

                // Cập nhật các training content vào cơ sở dữ liệu
                await _trainingDetailRepository.UpdateRangeAsync(existingDetails);

                return trainingDetail;
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, $"Application Error: {ex.Message}");
                throw; // Không bao bọc ngoại lệ này
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
                    throw new ArgumentException("Training Detail not found.");
                }

                var existingDetails = await _trainingDetailRepository.GetAllTrainingDetailByContentId(trainingDetail.TrainingContentId);

                var isNameDuplicate = existingDetails.Any(tc => tc.TrainingDetailName.Equals(trainingDetail.TrainingDetailName, StringComparison.OrdinalIgnoreCase) && tc.TrainingDetailId != trainingDetail.TrainingDetailId);
                if (isNameDuplicate)
                {
                    throw new ApplicationException("Training Content Name already exists.");
                }

                // Kiểm tra xem có thay đổi thứ tự Order hay không
                if (existingDetail.Order != trainingDetail.Order)
                {
                    // Điều chỉnh thứ tự của các nội dung đào tạo khác trong cùng một thư mục
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

                // Cập nhật thông tin của nội dung đào tạo
                existingDetail.TrainingDetailName = trainingDetail.TrainingDetailName;
                existingDetail.IsProof = trainingDetail.IsProof;
                existingDetail.MaxScore = trainingDetail.MaxScore;
                existingDetail.TypeofScore = trainingDetail.TypeofScore;
                existingDetail.CreateAt = trainingDetail.CreateAt;
                existingDetail.DeletedAt = trainingDetail.DeletedAt;
                existingDetail.Order = trainingDetail.Order;

                // Lưu thay đổi vào cơ sở dữ liệu
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

                // Kiểm tra xem nội dung đào tạo cần xóa có tồn tại trong cơ sở dữ liệu không
                var existinDetail = await _trainingDetailRepository.GetByIdAsync(trainingDetail.TrainingDetailId);
                if (existinDetail == null)
                {
                    throw new ArgumentException("Không tìm thấy chi tiêt rèn luyện cần xóa.");
                }

                // Lưu trữ ID của thư mục chứa nội dung đào tạo này để sử dụng sau này
                int contentId = existinDetail.TrainingContentId;

                // Xóa nội dung đào tạo khỏi cơ sở dữ liệu
                await _trainingDetailRepository.DeleteAsync(existinDetail);

                // Điều chỉnh lại thứ tự của các nội dung đào tạo còn lại trong cùng một thư mục
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
        #endregion
    }
}
