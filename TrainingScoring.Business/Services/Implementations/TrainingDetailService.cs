using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Implementations
{
    public class TrainingDetailService : ITrainingDetailService
    {
        private readonly ILogger<EvaluationFormService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ITrainingDetailRepository _trainingDetailRepository;

        public TrainingDetailService(ILogger<EvaluationFormService> logger, 
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
                    throw new Exception("Không có Chi tiết rèn luyện cả!");
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
                    throw new Exception("Không có khóa học nào");
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

        public Task<TrainingDetail> CreateTrainingDetailAsync(TrainingDetail trainingDetail)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingDetail> UpdateTrainingDetailAsync(TrainingDetail trainingDetail)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingDetail> DeleteTrainingDetailAsync(TrainingDetail trainingDetail)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
