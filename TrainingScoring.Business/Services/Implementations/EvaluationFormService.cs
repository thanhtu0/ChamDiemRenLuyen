using Microsoft.Extensions.Logging;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;
using Microsoft.AspNetCore.Http;

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

        public async Task<EvaluationForm> GetByCodeAsync(string code)
        {
            try
            {
                return await _evaluationFormRepository.GetByCodeAsync(code);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<EvaluationForm> CreateEvaluationFormAsync(EvaluationForm evaluationForm)
        {
            try
            {
                if (evaluationForm == null)
                {
                    throw new ArgumentNullException(nameof(evaluationForm), "Phiếu đánh giá không được để trống.");
                }

                // Kiểm tra xem có phiếu đánh giá nào trùng mã hay trùng tên không
                var existingFormWithSameCode = await _evaluationFormRepository.GetByCodeAsync(evaluationForm.EvaluationFormCode);
                if (existingFormWithSameCode != null)
                {
                    throw new Exception("Phiếu đánh giá đã tồn tại với mã tương tự.");
                }

                var existingFormWithSameName = await _evaluationFormRepository.GetByNameAsync(evaluationForm.EvaluationFormName);
                if (existingFormWithSameName != null)
                {
                    throw new Exception("Phiếu đánh giá đã tồn tại với tên tương tự.");
                }

                // Thực hiện thêm phiếu đánh giá mới vào cơ sở dữ liệu
                var createdEvaluationForm = await _evaluationFormRepository.CreateAsync(evaluationForm);

                return createdEvaluationForm;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi tạo phiếu đánh giá: {ex.Message}");
                throw;
            }
        }

        public async Task<EvaluationForm> UpdateEvaluationFormAsync(EvaluationForm evaluationForm)
        {
            try
            {
                if (evaluationForm == null)
                {
                    throw new ArgumentNullException(nameof(evaluationForm), "Phiếu đánh giá không được để trống.");
                }

                // Kiểm tra xem phiếu đánh giá có tồn tại trong cơ sở dữ liệu không
                var existingEvaluationForm = await _evaluationFormRepository.GetByIdAsync(evaluationForm.EvaluationFormId);
                if (existingEvaluationForm == null)
                {
                    throw new Exception("Không tìm thấy phiếu đánh giá để cập nhật.");
                }

                // Kiểm tra xem có phiếu đánh giá nào khác có mã giống với mã mới không
                var existingFormWithSameCode = await _evaluationFormRepository.GetByCodeAsync(evaluationForm.EvaluationFormCode);
                if (existingFormWithSameCode != null && existingFormWithSameCode.EvaluationFormId != evaluationForm.EvaluationFormId)
                {
                    throw new Exception("Phiếu đánh giá bạn thay đổi đã tồn tại, vui lòng chọn mã khác.");
                }

                // Cập nhật thông tin của phiếu đánh giá
                existingEvaluationForm.EvaluationFormCode = evaluationForm.EvaluationFormCode;
                existingEvaluationForm.EvaluationFormName = evaluationForm.EvaluationFormName;

                // Lưu các thay đổi vào cơ sở dữ liệu
                await _evaluationFormRepository.UpdateAsync(existingEvaluationForm);

                return existingEvaluationForm;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi cập nhật phiếu đánh giá: {ex.Message}");
                throw;
            }
        }

        public async Task<EvaluationForm> DeleteEvaluationFormAsync(EvaluationForm evaluationForm)
        {
            try
            {
                if (evaluationForm == null)
                {
                    throw new ArgumentNullException(nameof(evaluationForm), "Phiếu đánh giá không được để trống.");
                }

                // Xóa phiếu đánh giá khỏi cơ sở dữ liệu
                await _evaluationFormRepository.DeleteAsync(evaluationForm);

                // Trả về phiếu đánh giá đã xóa
                return evaluationForm;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa phiếu đánh giá: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> IsEvaluationFormExists(int id)
        {
            var existingForm = await _evaluationFormRepository.GetByIdAsync(id);
            return existingForm != null;
        }
        #endregion
    }
}
