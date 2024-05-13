using Microsoft.AspNetCore.Mvc;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.DomainModels;
using TrainingScoring.WebUI.Models;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EvaluationFormController : Controller
    {
        private readonly ILogger<SystemmanagementController> _logger;
        private readonly IEvaluationFormService _evaluationFormService;

        private readonly ITrainingDirectoryService _trainingDirectoryService;
        private readonly ITrainingContentService _trainingContentService;
        private readonly ITrainingDetailService _trainingDetailService;
        private readonly IAcademicYearService _academicYearService;

        public EvaluationFormController(ILogger<SystemmanagementController> logger, 
            IEvaluationFormService evaluationFormService, 
            ITrainingDirectoryService trainingDirectoryService, 
            ITrainingContentService trainingContentService, 
            ITrainingDetailService trainingDetailService, 
            IAcademicYearService academicYearService)
        {
            _logger = logger;
            _evaluationFormService = evaluationFormService;
            _trainingDirectoryService = trainingDirectoryService;
            _trainingContentService = trainingContentService;
            _trainingDetailService = trainingDetailService;
            _academicYearService = academicYearService;
        }

        public async Task<IActionResult> ShowListEvaluationForm()
        {
            try
            {
                List<EvaluationForm> evaluationForms = await _evaluationFormService.GetAllEvaluationFormsAsync();

                var evaluationFormVM = new EvaluationFormViewModel()
                {
                    EvaluationForms = evaluationForms
                };

                return View(evaluationFormVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IActionResult> EvaluationFormDetail(int id)
        {
            try
            {
                var evaluationForms = await _evaluationFormService.GetEvaluationFormByIdAsync(id);
                List<TrainingDirectory> trainingDirectories = await _trainingDirectoryService.GetAllTrainingDirectoriesAsync();
                List<TrainingContent> trainingContents = await _trainingContentService.GetAllTrainingContentsAsync();
                List<TrainingDetail> trainingDetails = await _trainingDetailService.GetAllTrainingDetailsAsync();

                var evaluationFormDetailVM = new EvaluationFormDetailsViewModel()
                {
                    EvaluationFormId = id,
                    EvaluationFormCode = evaluationForms.EvaluationFormCode,
                    EvaluationFormName = evaluationForms.EvaluationFormName,
                    TrainingDirectories = trainingDirectories,
                    TrainingContents = trainingContents,
                    TrainingDetails = trainingDetails
                };

                return View(evaluationFormDetailVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IActionResult> CreateEvaluationForm()
        {
            var academicYears = await _academicYearService.GetAllAcademicYearsAsync();
            var viewModel = new EvaluationFormDetailsViewModel
            {
                AcademicYears = academicYears
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluationForm(EvaluationForm evaluationForm)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        // Gọi service để tạo mới một phiếu đánh giá
            //        var createdEvaluationForm = await _evaluationFormService.CreateEvaluationFormAsync(evaluationForm);

            //        // Kiểm tra xem phiếu đánh giá đã được tạo thành công chưa
            //        if (createdEvaluationForm != null)
            //        {
            //            // Chuyển hướng đến action hiển thị chi tiết phiếu đánh giá mới tạo
            //            return RedirectToAction("EvaluationFormDetail", new { id = createdEvaluationForm.EvaluationFormId });
            //        }
            //        else
            //        {
            //            // Xử lý trường hợp tạo mới không thành công
            //            ModelState.AddModelError(string.Empty, "Failed to create evaluation form.");
            //            return View(evaluationForm); // Hiển thị lại view với dữ liệu đã nhập và thông báo lỗi
            //        }
            //    }
            //    else
            //    {
            //        // Xử lý trường hợp dữ liệu nhập vào không hợp lệ
            //        return View(evaluationForm); // Hiển thị lại view với dữ liệu đã nhập và thông báo lỗi
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Error: {ex.Message}");
            //    throw;
            //}
            try
            {
                if (ModelState.IsValid)
                {
                    // Gọi service để tạo mới một phiếu đánh giá
                    var createdEvaluationForm = await _evaluationFormService.CreateEvaluationFormAsync(evaluationForm);

                    // Kiểm tra xem phiếu đánh giá đã được tạo thành công chưa
                    if (createdEvaluationForm != null)
                    {
                        // Chuyển hướng đến action hiển thị danh sách các phiếu đánh giá
                        return RedirectToAction("ShowListEvaluationForm");
                    }
                    else
                    {
                        // Xử lý trường hợp tạo mới không thành công
                        ModelState.AddModelError(string.Empty, "Failed to create evaluation form.");
                        return View(evaluationForm); // Hiển thị lại view với dữ liệu đã nhập và thông báo lỗi
                    }
                }
                else
                {
                    // Xử lý trường hợp dữ liệu nhập vào không hợp lệ
                    return View(evaluationForm); // Hiển thị lại view với dữ liệu đã nhập và thông báo lỗi
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

    }
}
