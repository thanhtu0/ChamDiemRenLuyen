using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Implementations
{
    public class StudentScoreService : IStudentScoreService
    {
        private readonly ILogger<StudentScoreService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IStudentScoreDetailRepository _studentScoreDetailRepository;
        private readonly IStudentScoreContentRepository _studentScoreContentRepository;
        private readonly IScoreRepository _scoreRepository;

        private const int ProcessId = 3;

        public StudentScoreService(
            ILogger<StudentScoreService> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IStudentScoreDetailRepository studentScoreDetailRepository, 
            IStudentScoreContentRepository studentScoreContentRepository, 
            IScoreRepository scoreRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _studentScoreDetailRepository = studentScoreDetailRepository;
            _studentScoreContentRepository = studentScoreContentRepository;
            _scoreRepository = scoreRepository;
        }


        #region StudentScoreTrainingDetail
        public async Task<StudentScoreDetail> GetStudentTrainingDetailByIdAsync(int studentId, int detailId)
        {
            try
            {
                return await _studentScoreDetailRepository.GetStudentScore(studentId, detailId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<List<StudentScoreDetail>> GetStudentScoreDetailByIdAsync(int studentId)
        {
            try
            {
                var studentTrainingDetails = await _studentScoreDetailRepository.GetByIdAsync(studentId);

                if (studentTrainingDetails == null || !studentTrainingDetails.Any())
                {
                    throw new Exception("Điểm chi tiết rèn luyện này hiện chưa có!");
                }

                return studentTrainingDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<StudentScoreDetail> CreateStudentScoreDetailAsync(StudentScoreDetail studentScoreDetail)
        {
            try
            {
                await _studentScoreDetailRepository.CreateAsync(studentScoreDetail);
                return studentScoreDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<StudentScoreDetail> UpdateStudentScoreDetailAsync(StudentScoreDetail studentScoreDetail)
        {
            try
            {
                await _studentScoreDetailRepository.UpdateAsync(studentScoreDetail);
                return studentScoreDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region StudentScoreTrainingContent
        public async Task<List<StudentScoreContent>> GetStudentScoreContentByIdAsync(int studentId)
        {
            try
            {
                var studentScoreContents = await _studentScoreContentRepository.GetByIdAsync(studentId);

                if (studentScoreContents == null || !studentScoreContents.Any())
                {
                    throw new Exception("Điểm nội dung rèn luyện này hiện chưa có!");
                }

                return studentScoreContents;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<StudentScoreContent> GetStudentTrainingContentByIdAsync(int studentId, int contentId)
        {
            try
            {
                return await _studentScoreContentRepository.GetStudentScore(studentId, contentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<StudentScoreContent> CreateStudentScoreContentAsync(StudentScoreContent studentScoreContent)
        {
            try
            {
                await _studentScoreContentRepository.CreateAsync(studentScoreContent);
                return studentScoreContent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<StudentScoreContent> UpdateStudentScoreContentAsync(StudentScoreContent studentScoreContent)
        {
            try
            {
                await _studentScoreContentRepository.UpdateAsync(studentScoreContent);
                return studentScoreContent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region StudentScore
        public async Task<List<Score>> GetScorelByIdAsync(int studentId)
        {
            try
            {
                return await _scoreRepository.GetByStudentIdAsync(studentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<Score> GetScoreByIdAsync(int id, int scoreId)
        {
            try
            {
                return await _scoreRepository.GetByIdAsync(scoreId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<Score> CreateScoreAsync(Score score)
        {
            try
            {
                await _scoreRepository.CreateAsync(score);
                return score;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<Score> UpdateScoreAsync(Score score)
        {
            try
            {
                await _scoreRepository.UpdateAsync(score);
                return score;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }
        #endregion

        public async Task<Score> GetScoreAsync(int studentId, int academicYearId)
        {
            return await _scoreRepository.GetScoreAsync(studentId, academicYearId, ProcessId);
        }
    }
}
