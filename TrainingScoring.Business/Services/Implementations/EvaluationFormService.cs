using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Business.Services.Utilities;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Implementations;

namespace TrainingScoring.Business.Services.Implementations
{
    public class EvaluationFormService : IEvaluationFormService
    {
        private readonly ILogger<EvaluationFormService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IEvaluationFormRepository _evaluationFormRepository;

        public EvaluationFormService(ILogger<EvaluationFormService> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IEvaluationFormRepository evaluationFormRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _evaluationFormRepository = evaluationFormRepository;
        }


        #region EvaluationForm
        public async Task<List<EvaluationForm>> GetEvaluationFormsAsync()
        {
            try
            {
                var evaluationFormRepository = await _evaluationFormRepository.GetAllAsync();
                if (evaluationFormRepository == null)
                {
                    throw new Exception("Không có Danh mục rèn luyện cả!");
                }

                return evaluationFormRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<EvaluationForm> GetEvaluationFormByIdAsync(int id)
        {
            try
            {
                var evaluationFormRepository = await _evaluationFormRepository.GetByIdAsync(id);

                if (evaluationFormRepository == null)
                {
                    throw new Exception("Không có Phiếu đánh giá nào cả!");
                }

                return evaluationFormRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<EvaluationForm> CreateEvaluationFormAsync(EvaluationForm evaluationForm, int academicYearId)
        {
            throw new NotImplementedException();
        }

        public Task<EvaluationForm> UpdateEvaluationFormAsync(EvaluationForm evaluationForm)
        {
            throw new NotImplementedException();
        }

        public Task<EvaluationForm> DeleteEvaluationFormAsync(EvaluationForm evaluationForm)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
