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
        public async Task<List<EvaluationForm>> GetAllEvaluationFormsAsync()
        {
            try
            {
                var evaluationFormRepository = await _evaluationFormRepository.GetAllAsync();
                if (evaluationFormRepository == null)
                {
                    throw new Exception("Không có Phiếu đánh giá điểm rèn luyện cả!");
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
                    throw new Exception("Phiếu đánh giá điểm rèn luyện hiện không có!");
                }

                return evaluationFormRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<EvaluationForm> CreateEvaluationFormAsync(EvaluationForm evaluationForm)
        {
            //try
            //{
            //    if (evaluationForm == null)
            //    {
            //        throw new ArgumentNullException(nameof(evaluationForm), "Phiếu đánh giá không được để trống.");
            //    }

            //    // Thực hiện các kiểm tra hợp lệ khác nếu cần

            //    // Thực hiện thêm phiếu đánh giá mới vào cơ sở dữ liệu
            //    var createdEvaluationForm = await _evaluationFormRepository.CreateAsync(evaluationForm);

            //    return createdEvaluationForm;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"Lỗi khi tạo phiếu đánh giá: {ex.Message}");
            //    throw;
            //}
            try
            {
                if (evaluationForm == null)
                {
                    throw new ArgumentNullException(nameof(evaluationForm), "Phiếu đánh giá không được để trống.");
                }

                // Thực hiện các kiểm tra hợp lệ khác nếu cần

                // Thực hiện thêm phiếu đánh giá mới vào cơ sở dữ liệu
                var createdEvaluationFormId = await _evaluationFormRepository.CreateAsync(evaluationForm);

                // Lấy lại phiếu đánh giá mới được tạo từ cơ sở dữ liệu bằng ID
                var createdEvaluationForm = await _evaluationFormRepository.GetByIdAsync(createdEvaluationFormId);

                return createdEvaluationForm;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi tạo phiếu đánh giá: {ex.Message}");
                throw;
            }
        }

        public Task<EvaluationForm> UpdateEvaluationFormAsync(EvaluationForm evaluationForm)
        {
            //try
            //{
            //    if (evaluationForm == null)
            //    {
            //        throw new ArgumentNullException(nameof(evaluationForm), "Phiếu đánh giá không được để trống.");
            //    }

            //    // Kiểm tra xem phiếu đánh giá có tồn tại trong cơ sở dữ liệu không
            //    var existingEvaluationForm = await _evaluationFormRepository.GetByIdAsync(evaluationForm.EvaluationFormId);
            //    if (existingEvaluationForm == null)
            //    {
            //        throw new Exception("Không tìm thấy phiếu đánh giá để cập nhật.");
            //    }

            //    // Cập nhật thông tin của phiếu đánh giá
            //    existingEvaluationForm.EvaluationFormCode = evaluationForm.EvaluationFormCode;
            //    existingEvaluationForm.EvaluationFormName = evaluationForm.EvaluationFormName;

            //    // Lưu các thay đổi vào cơ sở dữ liệu
            //    var updatedEvaluationForm = await _evaluationFormRepository.UpdateAsync(existingEvaluationForm);

            //    return updatedEvaluationForm;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"Lỗi khi cập nhật phiếu đánh giá: {ex.Message}");
            //    throw;
            //}
            throw new NotImplementedException();
        }

        public Task<EvaluationForm> DeleteEvaluationFormAsync(EvaluationForm evaluationForm)
        {
            //try
            //{
            //    if (evaluationForm == null)
            //    {
            //        throw new ArgumentNullException(nameof(evaluationForm), "Phiếu đánh giá không được để trống.");
            //    }

            //    // Kiểm tra xem phiếu đánh giá có tồn tại trong cơ sở dữ liệu không
            //    var existingEvaluationForm = await _evaluationFormRepository.GetByIdAsync(evaluationForm.EvaluationFormId);
            //    if (existingEvaluationForm == null)
            //    {
            //        throw new Exception("Không tìm thấy phiếu đánh giá để xóa.");
            //    }

            //    // Xóa phiếu đánh giá khỏi cơ sở dữ liệu
            //    var deletedEvaluationForm = await _evaluationFormRepository.DeleteAsync(existingEvaluationForm);

            //    return deletedEvaluationForm;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, $"Lỗi khi xóa phiếu đánh giá: {ex.Message}");
            //    throw;
            //}
            throw new NotImplementedException();
        }
        #endregion
    }
}
