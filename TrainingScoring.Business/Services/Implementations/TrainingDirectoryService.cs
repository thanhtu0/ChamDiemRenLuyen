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
    public class TrainingDirectoryService : ITrainingDirectoryService
    {
        private readonly ILogger<EvaluationFormService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ITrainingDirectoryRepository _trainingDirectoryRepository;

        public TrainingDirectoryService(ILogger<EvaluationFormService> logger, 
            IHttpContextAccessor httpContextAccessor, 
            ITrainingDirectoryRepository trainingDirectoryRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _trainingDirectoryRepository = trainingDirectoryRepository;
        }

        #region TrainingDirectory
        public async Task<List<TrainingDirectory>> GetTrainingDirectoriesAsync()
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
                    throw new Exception("Không có khóa học nào");
                }

                return trainingDirectoryRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public Task<TrainingDirectory> CreateTrainingDirectoryAsync(TrainingDirectory trainingDirectory)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingDirectory> UpdateTrainingDirectoryAsync(TrainingDirectory trainingDirectory)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingDirectory> DeleteTrainingDirectoryAsync(TrainingDirectory trainingDirectory)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
