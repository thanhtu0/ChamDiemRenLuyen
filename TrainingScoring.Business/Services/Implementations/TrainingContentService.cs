using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
                    throw new Exception("Không có Nội dung rèn luyện nào cả!");
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
                    throw new Exception("Không có Nội dung rèn luyện cần tìm");
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
                    throw new ApplicationException("Nội dung rèn luyện đã tồn tại. Vui lòng nhập lại");
                }

                int newIndex = existingContents.Count;

                for (int i = 0; i < existingContents.Count; i++)
                {
                    if (existingContents[i].Order >= trainingContent.Order)
                    {
                        newIndex = i;
                        break;
                    }
                }

                for (int i = newIndex; i < existingContents.Count; i++)
                {
                    existingContents[i].Order++;
                }

                existingContents.Insert(newIndex, trainingContent);

                await _trainingContentRepository.UpdateRangeAsync(existingContents);

                return trainingContent;
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

        public async Task<TrainingContent> UpdateTrainingContentAsync(TrainingContent trainingContent)
        {
            try
            {
                var existingContent = await _trainingContentRepository.GetByIdAsync(trainingContent.TrainingContentId);
                if (existingContent == null)
                {
                    throw new ArgumentException("Không tìm thấy nội dung rèn luyện.");
                }

                var existingContents = await _trainingContentRepository.GetAllTrainingContentByDirectoryId(trainingContent.TrainingDirectoryId);

                var isNameDuplicate = existingContents.Any(tc => tc.TrainingContentName.Equals(trainingContent.TrainingContentName, StringComparison.OrdinalIgnoreCase) && tc.TrainingContentId != trainingContent.TrainingContentId);
                if (isNameDuplicate)
                {
                    throw new ApplicationException("Nội dung rèn luyện đã tồn tại.");
                }

                if (existingContent.Order != trainingContent.Order)
                {
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

                existingContent.TrainingContentName = trainingContent.TrainingContentName;
                existingContent.IsProof = trainingContent.IsProof;
                existingContent.MaxScore = trainingContent.MaxScore;
                existingContent.TypeofScore = trainingContent.TypeofScore;
                existingContent.CreateAt = trainingContent.CreateAt;
                existingContent.DeletedAt = trainingContent.DeletedAt;
                existingContent.Order = trainingContent.Order;

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

                var existingContent = await _trainingContentRepository.GetByIdAsync(trainingContent.TrainingContentId);
                if (existingContent == null)
                {
                    throw new ArgumentException("Không tìm thấy nội dung đào tạo cần xóa.");
                }

                int directoryId = existingContent.TrainingDirectoryId;

                await _trainingContentRepository.DeleteAsync(existingContent);

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

        public async Task<bool> IsNameDuplicateAsync(int trainingContentId, int trainingDirectoryId, string trainingContentName)
        {
            var existingContents = await _trainingContentRepository.GetAllTrainingContentByDirectoryId(trainingDirectoryId);
            return existingContents.Any(tc => tc.TrainingContentName.Equals(trainingContentName, StringComparison.OrdinalIgnoreCase) && tc.TrainingContentId != trainingContentId);
        }

        #endregion
    }
}
