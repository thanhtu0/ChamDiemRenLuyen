using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Implementations
{
    public class TrainingDirectoryService : ITrainingDirectoryService
    {
        private readonly ILogger<TrainingDirectoryService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ITrainingDirectoryRepository _trainingDirectoryRepository;

        public TrainingDirectoryService(ILogger<TrainingDirectoryService> logger,
            IHttpContextAccessor httpContextAccessor,
            ITrainingDirectoryRepository trainingDirectoryRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _trainingDirectoryRepository = trainingDirectoryRepository;
        }

        #region TrainingDirectory
        public async Task<List<TrainingDirectory>> GetAllTrainingDirectoriesAsync()
        {
            try
            {
                var trainingDirectoryRepository = await _trainingDirectoryRepository.GetAllAsync();
                if (trainingDirectoryRepository == null)
                {
                    throw new Exception("Không có Danh mục rèn luyện cả!");
                }

                return trainingDirectoryRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<TrainingDirectory> GetTrainingDirectoryByIdAsync(int id)
        {
            try
            {
                var trainingDirectoryRepository = await _trainingDirectoryRepository.GetByIdAsync(id);

                if (trainingDirectoryRepository == null)
                {
                    throw new Exception("Danh mục rèn luyện này không có");
                }

                return trainingDirectoryRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TrainingDirectory>> GetAllTrainingDirectoryByEFormId(int id)
        {
            try
            {
                var trainingDirectories = await _trainingDirectoryRepository.GetAllTrainingDirectoryByEFormId(id);

                if (trainingDirectories == null || !trainingDirectories.Any())
                {
                    return new List<TrainingDirectory>();
                }

                return trainingDirectories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<TrainingDirectory> CreateTrainingDirectoryAsync(TrainingDirectory trainingDirectory)
        {
            try
            {
                var existingDirectories = await _trainingDirectoryRepository.GetAllTrainingDirectoryByEFormId(trainingDirectory.EvaluationFormId);

                var isOrderDuplicate = existingDirectories.Any(td => td.Order == trainingDirectory.Order);
                var isNameDuplicate = existingDirectories.Any(td => td.TrainingDirectoryName.Equals(trainingDirectory.TrainingDirectoryName, StringComparison.OrdinalIgnoreCase));

                if (isNameDuplicate)
                {
                    throw new ApplicationException("Danh mục đã tồn tại. Vui lòng nhập lại.");
                }

                if (existingDirectories == null || !existingDirectories.Any())
                {
                    trainingDirectory.Order = 1;
                }
                else if (isOrderDuplicate)
                {
                    foreach (var directory in existingDirectories.Where(d => d.Order >= trainingDirectory.Order))
                    {
                        directory.Order++;
                    }

                    await _trainingDirectoryRepository.UpdateRangeAsync(existingDirectories);
                }
                else
                {
                    var maxOrder = existingDirectories.Max(d => d.Order);
                    trainingDirectory.Order = Math.Min(trainingDirectory.Order, maxOrder + 1);
                }

                return await _trainingDirectoryRepository.CreateAsync(trainingDirectory);
            }
            catch (ApplicationException ex)
            {
                _logger.LogError(ex, $"Application Error: {ex.Message}");
                throw; // Không bao bọc ngoại lệ này
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw new ApplicationException("Error occurred while creating training directory", ex);
            }
        }

        public async Task<TrainingDirectory> UpdateTrainingDirectoryAsync(TrainingDirectory trainingDirectory)
        {
            try
            {
                var existingDirectory = await _trainingDirectoryRepository.GetByIdAsync(trainingDirectory.TrainingDirectoryId);
                if (existingDirectory == null)
                {
                    throw new ArgumentException("Không tìm thấy danh mục rèn luyện cần cập nhật.");
                }

                var existingDirectories = await _trainingDirectoryRepository.GetAllTrainingDirectoryByEFormId(trainingDirectory.EvaluationFormId);

                var isOrderDuplicate = existingDirectories.Any(td => td.Order == trainingDirectory.Order && td.TrainingDirectoryId != trainingDirectory.TrainingDirectoryId);
                if (isOrderDuplicate)
                {
                    await AdjustOrderAfterUpdateAsync(trainingDirectory.EvaluationFormId, existingDirectory.Order, trainingDirectory.Order);
                }

                existingDirectory.Order = trainingDirectory.Order;
                existingDirectory.TrainingDirectoryName = trainingDirectory.TrainingDirectoryName;
                existingDirectory.MaxScore = trainingDirectory.MaxScore;

                await _trainingDirectoryRepository.UpdateAsync(existingDirectory);

                return existingDirectory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating training directory: {ex.Message}");
                throw new ApplicationException("Error occurred while updating training directory", ex);
            }
        }

        public async Task<TrainingDirectory> DeleteTrainingDirectoryAsync(TrainingDirectory trainingDirectory)
        {
            try
            {
                if (trainingDirectory == null)
                {
                    throw new ArgumentNullException(nameof(trainingDirectory), "Danh mục rèn luyện không được để trống.");
                }

                var existingDirectory = await _trainingDirectoryRepository.GetByIdAsync(trainingDirectory.TrainingDirectoryId);
                if (existingDirectory == null)
                {
                    throw new ArgumentException("Không tìm thấy danh mục rèn luyện cần xóa.");
                }

                await _trainingDirectoryRepository.DeleteAsync(existingDirectory);

                await AdjustOrdersAfterDeletionAsync(trainingDirectory.EvaluationFormId);

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
            return await _trainingDirectoryRepository.GetMaxOrderAsync();
        }

        public async Task<bool> IsOrderOrNameDuplicateAsync(int evaluationFormId, int order, string trainingDirectoryName)
        {
            var existingDirectories = await _trainingDirectoryRepository.GetAllTrainingDirectoryByEFormId(evaluationFormId);

            return existingDirectories.Any(td => td.Order == order || td.TrainingDirectoryName.Equals(trainingDirectoryName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<bool> IsNameDuplicateAsync(int trainingDirectoryId, int evaluationFormId, string trainingDirectoryName)
        {
            var existingDirectories = await _trainingDirectoryRepository.GetAllTrainingDirectoryByEFormId(evaluationFormId);
            return existingDirectories.Any(td => td.TrainingDirectoryName.Equals(trainingDirectoryName, StringComparison.OrdinalIgnoreCase) && td.TrainingDirectoryId != trainingDirectoryId);
        }

        public async Task AdjustOrdersAsync(int evaluationFormId, int newOrder)
        {
            var directories = await _trainingDirectoryRepository.GetAllTrainingDirectoryByEFormId(evaluationFormId);

            foreach (var directory in directories.Where(d => d.Order >= newOrder))
            {
                directory.Order++;
            }

            await _trainingDirectoryRepository.UpdateRangeAsync(directories);
        }

        public async Task AdjustOrderAfterUpdateAsync(int evaluationFormId, int oldOrder, int newOrder)
        {
            try
            {
                var directories = await _trainingDirectoryRepository.GetAllTrainingDirectoryByEFormId(evaluationFormId);

                foreach (var directory in directories)
                {
                    if (directory.Order == oldOrder)
                    {
                        directory.Order = newOrder;
                    }
                    else if ((oldOrder < newOrder && directory.Order > oldOrder && directory.Order <= newOrder) ||
                             (oldOrder > newOrder && directory.Order < oldOrder && directory.Order >= newOrder))
                    {
                        directory.Order += (newOrder > oldOrder) ? -1 : 1;
                    }

                    await _trainingDirectoryRepository.UpdateAsync(directory);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while adjusting order after update: {ex.Message}");
                throw;
            }
        }

        public async Task AdjustOrdersAfterDeletionAsync(int evaluationFormId)
        {
            var directories = await _trainingDirectoryRepository.GetAllTrainingDirectoryByEFormId(evaluationFormId);

            int order = 1;
            foreach (var directory in directories.OrderBy(d => d.Order))
            {
                directory.Order = order++;
            }

            await _trainingDirectoryRepository.UpdateRangeAsync(directories);
        }

        #endregion
    }
}
