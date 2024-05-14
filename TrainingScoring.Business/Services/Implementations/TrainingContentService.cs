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

                // Kiểm tra trùng lặp order hoặc name
                var isOrderDuplicate = existingContents.Any(td => td.Order == trainingContent.Order);
                var isNameDuplicate = existingContents.Any(td => td.TrainingContentName.Equals(trainingContent.TrainingContentName, StringComparison.OrdinalIgnoreCase));

                if (isNameDuplicate)
                {
                    throw new ApplicationException("Training Content Name already exists.");
                }

                if (isOrderDuplicate)
                {
                    // Điều chỉnh order của các TrainingDirectory khác
                    foreach (var directory in existingContents.Where(d => d.Order >= trainingContent.Order))
                    {
                        directory.Order++;
                    }

                    await _trainingContentRepository.UpdateRangeAsync(existingContents);
                }

                // Thêm mới Training Directory
                return await _trainingContentRepository.CreateAsync(trainingContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw new ApplicationException("Error occurred while creating training directory", ex);
            }
        }

        public async Task<TrainingContent> UpdateTrainingContentAsync(TrainingContent trainingContent)
        {
            try
            {
                var existingContent = await _trainingContentRepository.GetByIdAsync(trainingContent.TrainingDirectoryId);
                if (existingContent == null)
                {
                    throw new ArgumentException("Không tìm thấy nội dung rèn luyện cần cập nhật.");
                }

                existingContent.Order = trainingContent.Order;
                existingContent.TrainingContentName = trainingContent.TrainingContentName;
                existingContent.IsProof = trainingContent.IsProof;
                existingContent.MaxScore = trainingContent.MaxScore;
                existingContent.TypeofScore = trainingContent.TypeofScore;


                await _trainingContentRepository.UpdateAsync(existingContent);

                return existingContent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi cập nhật nội dung rèn luyện: {ex.Message}");
                throw;
            }
        }

        public async Task<TrainingContent> DeleteTrainingContentAsync(TrainingContent trainingContent)
        {
            try
            {
                if (trainingContent == null)
                {
                    throw new ArgumentNullException(nameof(trainingContent), "Nội dung rèn luyện không được để trống.");
                }

                // Kiểm tra xem danh mục rèn luyện cần xóa có tồn tại trong cơ sở dữ liệu không
                var existingDirectory = await _trainingContentRepository.GetByIdAsync(trainingContent.TrainingDirectoryId);
                if (existingDirectory == null)
                {
                    throw new ArgumentException("Không tìm thấy danh mục rèn luyện cần xóa.");
                }

                // Xóa danh mục rèn luyện khỏi cơ sở dữ liệu
                await _trainingContentRepository.DeleteAsync(existingDirectory);

                // Điều chỉnh lại thứ tự của các danh mục còn lại
                await AdjustOrdersAfterDeletionAsync(trainingContent.TrainingDirectoryId);

                return existingDirectory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa danh mục rèn luyện: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GetMaxOrderAsync()
        {
            return await _trainingContentRepository.GetMaxOrderAsync();
        }

        public async Task<bool> IsOrderOrNameDuplicateAsync(int trainingDirectoryId, int order, string trainingContentName)
        {
            var existingContents = await _trainingContentRepository.GetAllTrainingContentByDirectoryId(trainingDirectoryId);

            return existingContents.Any(td => td.Order == order || td.TrainingContentName.Equals(trainingContentName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task AdjustOrdersAsync(int trainingDirectoryId, int newOrder)
        {
            var contents = await _trainingContentRepository.GetAllTrainingContentByDirectoryId(trainingDirectoryId);

            foreach (var content in contents.Where(d => d.Order >= newOrder))
            {
                content.Order++;
            }

            await _trainingContentRepository.UpdateRangeAsync(contents);
        }

        public async Task AdjustOrdersAfterDeletionAsync(int trainingDirectoryId)
        {
            var contents = await _trainingContentRepository.GetAllTrainingContentByDirectoryId(trainingDirectoryId);

            int order = 1;
            foreach (var content in contents.OrderBy(d => d.Order))
            {
                content.Order = order++;
            }

            await _trainingContentRepository.UpdateRangeAsync(contents);
        }
        #endregion
    }
}
