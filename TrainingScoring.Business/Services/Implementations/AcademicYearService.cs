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
    public class AcademicYearService : IAcademicYearService
    {
        private readonly ILogger<EvaluationFormService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IAcademicYearRepository _academicYearRepository;

        public AcademicYearService(ILogger<EvaluationFormService> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IAcademicYearRepository academicYearRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _academicYearRepository = academicYearRepository;
        }



        #region AcademicYear
        public async Task<List<AcademicYear>> GetAllAcademicYearsAsync()
        {
            try
            {
                var academicYearRepository = await _academicYearRepository.GetAllAsync();
                if (academicYearRepository == null)
                {
                    throw new Exception("Không có năm học nào cả!");
                }

                return academicYearRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<AcademicYear> GetAcademicYearByIdAsync(int id)
        {
            try
            {
                var academicYearRepository = await _academicYearRepository.GetByIdAsync(id);

                if (academicYearRepository == null)
                {
                    throw new Exception("Phiếu đánh giá điểm rèn luyện hiện không có!");
                }

                return academicYearRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<AcademicYear> CreateAcademicYearAsync(AcademicYear academicYear)
        {
            throw new NotImplementedException();
        }

        public Task<AcademicYear> DeleteAcademicYearAsync(AcademicYear academicYear)
        {
            throw new NotImplementedException();
        }

        public Task<AcademicYear> UpdateAcademicYearAsync(AcademicYear academicYear)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
