using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<TrainingDetail> GetTrainingDetailsByIdAsync(int id)
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

        public Task<TrainingDetail> CreateTrainingDetailsAsync(TrainingDetail trainingDetail)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingDetail> UpdateTrainingDetailsAsync(TrainingDetail trainingDetail)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingDetail> DeleteTrainingDetailsAsync(TrainingDetail trainingDetail)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
