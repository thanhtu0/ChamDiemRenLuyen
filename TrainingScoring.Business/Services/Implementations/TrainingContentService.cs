using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data.Repositories.Implementations;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Implementations
{
    public class TrainingContentService : ITrainingContentService
    {
        private readonly ILogger<TrainingContentService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ITrainingContentRepository _trainingContentRepository;

        public TrainingContentService(ILogger<TrainingContentService> logger,
            IHttpContextAccessor httpContextAccessor,
            ITrainingContentRepository trainingContentRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _trainingContentRepository = trainingContentRepository;
        }


        #region TrainingContent
        public async Task<List<TrainingContent>> GetAllTrainingContentsAsync()
        {
            try
            {
                var trainingContentRepository = await _trainingContentRepository.GetAllAsync();
                if (trainingContentRepository == null)
                {
                    throw new Exception("Không có Nội dung rèn luyện cả!");
                }

                return trainingContentRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<TrainingContent> GetTrainingContentByIdAsync(int id)
        {
            try
            {
                var trainingContentRepository = await _trainingContentRepository.GetByIdAsync(id);

                if (trainingContentRepository == null)
                {
                    throw new Exception("Không có Nội dung rèn luyện");
                }

                return trainingContentRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TrainingContent>> GetAllTrainingContentByDirectoryId(int id)
        {
            try
            {
                var trainingContents = await _trainingContentRepository.GetAllTrainingContentByDirectoryId(id);

                if (trainingContents == null || !trainingContents.Any())
                {
                    return new List<TrainingContent>();
                }

                return trainingContents;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi: {ex.Message}");
                throw;
            }
        }

        public async Task<TrainingContent> CreateTrainingContentAsync(TrainingContent trainingContent)
        {

            try
            {
                var existingContents = await _trainingContentRepository.GetAllTrainingContentByDirectoryId(trainingContent.TrainingDirectoryId);

                var isNameDuplicate = existingContents.Any(tc => tc.TrainingContentName.Equals(trainingContent.TrainingContentName, StringComparison.OrdinalIgnoreCase));

                if (isNameDuplicate)
                {
                    throw new ApplicationException("Training Content Name already exists.");
                }

                // Tìm vị trí thích hợp để chèn mới
                int newIndex = existingContents.Count;

                for (int i = 0; i < existingContents.Count; i++)
                {
                    if (existingContents[i].Order >= trainingContent.Order)
                    {
                        newIndex = i;
                        break;
                    }
                }

                // Điều chỉnh thứ tự của các training content sau newIndex
                for (int i = newIndex; i < existingContents.Count; i++)
                {
                    existingContents[i].Order++;
                }

                // Thêm mới training content vào vị trí đã chọn
                existingContents.Insert(newIndex, trainingContent);

                // Cập nhật các training content vào cơ sở dữ liệu
                await _trainingContentRepository.UpdateRangeAsync(existingContents);

                return trainingContent;
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

        public async Task<TrainingContent> UpdateTrainingContentAsync(TrainingContent trainingContent)
        {
            try
            {
                var existingContent = await _trainingContentRepository.GetByIdAsync(trainingContent.TrainingContentId);
                if (existingContent == null)
                {
                    throw new ArgumentException("Training Content not found.");
                }

                var existingContents = await _trainingContentRepository.GetAllTrainingContentByDirectoryId(trainingContent.TrainingDirectoryId);

                var isNameDuplicate = existingContents.Any(tc => tc.TrainingContentName.Equals(trainingContent.TrainingContentName, StringComparison.OrdinalIgnoreCase) && tc.TrainingContentId != trainingContent.TrainingContentId);
                if (isNameDuplicate)
                {
                    throw new ApplicationException("Training Content Name already exists.");
                }

                // Kiểm tra xem có thay đổi thứ tự Order hay không
                if (existingContent.Order != trainingContent.Order)
                {
                    // Điều chỉnh thứ tự của các nội dung đào tạo khác trong cùng một thư mục
                    if (existingContent.Order > trainingContent.Order)
                    {
                        foreach (var content in existingContents.Where(tc => tc.Order >= trainingContent.Order && tc.Order < existingContent.Order))
                        {
                            content.Order++;
                        }
                    }
                    else
                    {
                        foreach (var content in existingContents.Where(tc => tc.Order <= trainingContent.Order && tc.Order > existingContent.Order))
                        {
                            content.Order--;
                        }
                    }
                }

                // Cập nhật thông tin của nội dung đào tạo
                existingContent.TrainingContentName = trainingContent.TrainingContentName;
                existingContent.IsProof = trainingContent.IsProof;
                existingContent.MaxScore = trainingContent.MaxScore;
                existingContent.TypeofScore = trainingContent.TypeofScore;
                existingContent.CreateAt = trainingContent.CreateAt;
                existingContent.DeletedAt = trainingContent.DeletedAt;
                existingContent.Order = trainingContent.Order;

                // Lưu thay đổi vào cơ sở dữ liệu
                return await _trainingContentRepository.UpdateAsync(existingContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating training content: {ex.Message}");
                throw new ApplicationException("Error occurred while updating training content", ex);
            }
        }

        public async Task<TrainingContent> DeleteTrainingContentAsync(TrainingContent trainingContent)
        {
            try
            {
                if (trainingContent == null)
                {
                    throw new ArgumentNullException(nameof(trainingContent), "Nội dung đào tạo không được để trống.");
                }

                // Kiểm tra xem nội dung đào tạo cần xóa có tồn tại trong cơ sở dữ liệu không
                var existingContent = await _trainingContentRepository.GetByIdAsync(trainingContent.TrainingContentId);
                if (existingContent == null)
                {
                    throw new ArgumentException("Không tìm thấy nội dung đào tạo cần xóa.");
                }

                // Lưu trữ ID của thư mục chứa nội dung đào tạo này để sử dụng sau này
                int directoryId = existingContent.TrainingDirectoryId;

                // Xóa nội dung đào tạo khỏi cơ sở dữ liệu
                await _trainingContentRepository.DeleteAsync(existingContent);

                // Điều chỉnh lại thứ tự của các nội dung đào tạo còn lại trong cùng một thư mục
                await AdjustOrdersAfterDeletionAsync(directoryId);

                return existingContent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa nội dung đào tạo: {ex.Message}");
                throw;
            }
        }

        public async Task AdjustOrdersAfterDeletionAsync(int trainingDirectoryId)
        {
            var contents = await _trainingContentRepository.GetAllTrainingContentByDirectoryId(trainingDirectoryId);

            int order = 1;
            foreach (var content in contents.OrderBy(c => c.Order))
            {
                content.Order = order++;
            }

            await _trainingContentRepository.UpdateRangeAsync(contents);
        }

        public async Task<int> GetMaxOrderAsync(int trainingDirectoryId)
        {
            return await _trainingContentRepository.GetMaxOrderAsync(trainingDirectoryId);
        }

        #endregion
    }
}
