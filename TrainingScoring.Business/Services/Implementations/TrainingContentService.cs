using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data.Repositories.Implementations;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Implementations
{
    public class TrainingContentService : ITrainingContentService
    {
        private readonly ILogger<EvaluationFormService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ITrainingContentRepository _trainingContentRepository;

        public TrainingContentService(ILogger<EvaluationFormService> logger, 
            IHttpContextAccessor httpContextAccessor, 
            ITrainingContentRepository trainingContentRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _trainingContentRepository = trainingContentRepository;
        }


        #region TrainingContent
        public async Task<List<TrainingContent>> GetTrainingContentsAsync()
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

        public async Task<TrainingContent> GetTrainingContentsByIdAsync(int id)
        {
            try
            {
                var trainingContentRepository = await _trainingContentRepository.GetByIdAsync(id);

                if (trainingContentRepository == null)
                {
                    throw new Exception("Không có khóa học nào");
                }

                return trainingContentRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public Task<TrainingContent> CreateTrainingContentsAsync(TrainingContent trainingContent)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingContent> UpdateTrainingContentsAsync(TrainingContent trainingContent)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingContent> DeleteTrainingContentsAsync(TrainingContent trainingContent)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
