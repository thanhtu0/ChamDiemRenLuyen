using Microsoft.AspNetCore.Mvc;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.DomainModels;
using TrainingScoring.WebUI.Models;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EvaluationFormController : Controller
    {
        private readonly ILogger<EvaluationFormController> _logger;
        private readonly IEvaluationFormService _evaluationFormService;

        private readonly ITrainingDirectoryService _trainingDirectoryService;
        private readonly ITrainingContentService _trainingContentService;
        private readonly ITrainingDetailService _trainingDetailService;
        private readonly IAcademicYearService _academicYearService;

        public EvaluationFormController(ILogger<EvaluationFormController> logger,
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
        /// <summary>
        /// Show EvaluationForms
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Show EvaluationForms Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EvaluationFormDetail(int id)
        {
            try
            {
                var evaluationForms = await _evaluationFormService.GetEvaluationFormByIdAsync(id);
                List<TrainingDirectory> trainingDirectories = await _trainingDirectoryService.GetAllTrainingDirectoryByEFormId(evaluationForms.EvaluationFormId);

                if (trainingDirectories == null || !trainingDirectories.Any())
                {
                    trainingDirectories = new List<TrainingDirectory>();
                }

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

        #region Create, Update, Delete EvaluationForms
        /// <summary>
        /// Create EvaluationForms
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CreateEvaluationForm()
        {
            var academicYears = await _academicYearService.GetAllAcademicYearsAsync();
            var viewModel = new EvaluationFormDetailsViewModel
            {
                AcademicYears = academicYears
            };

            // Kiểm tra xem có thông báo lỗi từ TempData không
            if (TempData["ErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["ErrorMessage"].ToString());
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluationForm(EvaluationForm evaluationForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Kiểm tra xem phiếu đánh giá đã tồn tại hay không
                    var existingFormWithSameCode = await _evaluationFormService.GetByCodeAsync(evaluationForm.EvaluationFormCode);
                    if (existingFormWithSameCode != null)
                    {
                        TempData["ErrorMessage"] = "Phiếu đánh giá đã tồn tại với mã tương tự. Vui lòng thử lại với mã khác.";
                        return RedirectToAction("CreateEvaluationForm");
                    }

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
                        TempData["ErrorMessage"] = "Failed to create evaluation form.";
                        return RedirectToAction("CreateEvaluationForm");
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
        /// <summary>
        /// Update EvaluationForms
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateEvaluationForm(int id)
        {
            try
            {
                var evaluationForm = await _evaluationFormService.GetEvaluationFormByIdAsync(id);

                if (evaluationForm == null)
                {
                    return NotFound();
                }

                if (TempData["ErrorMessage"] != null)
                {
                    ModelState.AddModelError(string.Empty, TempData["ErrorMessage"].ToString());
                }

                return View(evaluationForm);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvaluationForm(EvaluationForm evaluationForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Thực hiện cập nhật EvaluationForm
                    var updatedEvaluationForm = await _evaluationFormService.UpdateEvaluationFormAsync(evaluationForm);

                    // Chuyển hướng đến trang hiển thị danh sách các phiếu đánh giá
                    return RedirectToAction("ShowListEvaluationForm");
                }
                else
                {
                    // Nếu dữ liệu không hợp lệ, hiển thị tất cả các thông báo lỗi trong ModelState
                    return View(evaluationForm);
                }
            }
            catch (Exception ex)
            {
                // Nếu xảy ra lỗi, thêm thông báo lỗi vào ModelState
                ModelState.AddModelError(string.Empty, ex.Message);

                // Hiển thị lại trang cập nhật với thông tin của EvaluationForm và thông báo lỗi
                return View(evaluationForm);
            }
        }
        /// <summary>
        /// Delete EvaluationForms
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteEvaluationForm(int id)
        {
            try
            {
                var evaluationFormToDelete = await _evaluationFormService.GetEvaluationFormByIdAsync(id);

                if (evaluationFormToDelete == null)
                {
                    return NotFound();
                }

                var deletedEvaluationForm = await _evaluationFormService.DeleteEvaluationFormAsync(evaluationFormToDelete);

                if (deletedEvaluationForm != null)
                {
                    // Nếu xóa thành công, chuyển hướng đến trang danh sách các phiếu đánh giá
                    return RedirectToAction("ShowListEvaluationForm");
                }
                else
                {
                    // Nếu xóa không thành công, thêm thông báo lỗi và chuyển hướng đến trang danh sách các phiếu đánh giá
                    ModelState.AddModelError(string.Empty, "Failed to delete evaluation form.");
                    return RedirectToAction("ShowListEvaluationForm");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Create, Update, Delete TrainingDirectory
        public IActionResult CreateTrainingDirectory(int evaluationFormId)
        {
            var viewModel = new TrainingDirectoryViewModel
            {
                EvaluationFormId = evaluationFormId
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingDirectory(TrainingDirectoryViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var maxOrder = await _trainingDirectoryService.GetMaxOrderAsync();

                    if (viewModel.Order > maxOrder)
                    {
                        viewModel.Order = maxOrder + 1; 
                    }

                    var trainingDirectory = viewModel.ToTrainingDirectory();

                    var createdTrainingDirectory = await _trainingDirectoryService.CreateTrainingDirectoryAsync(trainingDirectory);

                    if (createdTrainingDirectory != null)
                    {
                        return RedirectToAction("EvaluationFormDetail", new { id = viewModel.EvaluationFormId });
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to create training directory.";
                        return RedirectToAction("CreateTrainingDirectory", new { evaluationFormId = viewModel.EvaluationFormId });
                    }
                }
                else
                {
                    return View(viewModel);
                }
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IActionResult> UpdateTrainingDirectory(int id)
        {
            try
            {
                var trainingDirectory = await _trainingDirectoryService.GetTrainingDirectoryByIdAsync(id);

                if (trainingDirectory == null)
                {
                    return NotFound();
                }

                var viewModel = new TrainingDirectoryViewModel
                {
                    TrainingDirectoryId = trainingDirectory.TrainingDirectoryId,
                    EvaluationFormId = trainingDirectory.EvaluationFormId,
                    TrainingDirectoryName = trainingDirectory.TrainingDirectoryName,
                    Order = trainingDirectory.Order,
                    MaxScore = trainingDirectory.MaxScore // Thêm MaxScore vào nếu cần
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTrainingDirectory(TrainingDirectoryViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Kiểm tra tên trùng lặp
                    var isNameDuplicate = await _trainingDirectoryService.IsNameDuplicateAsync(viewModel.TrainingDirectoryId, viewModel.EvaluationFormId, viewModel.TrainingDirectoryName);
                    if (isNameDuplicate)
                    {
                        ModelState.AddModelError("TrainingDirectoryName", "Training Directory Name already exists.");
                        return View(viewModel);
                    }

                    // Lấy giá trị MaxOrder hiện tại
                    var maxOrder = await _trainingDirectoryService.GetMaxOrderAsync();

                    // Điều chỉnh Order nếu cần thiết
                    if (viewModel.Order > maxOrder)
                    {
                        viewModel.Order = maxOrder + 1;
                    }

                    var updatedTrainingDirectory = await _trainingDirectoryService.UpdateTrainingDirectoryAsync(viewModel.ToTrainingDirectory());

                    if (updatedTrainingDirectory != null)
                    {
                        return RedirectToAction("EvaluationFormDetail", new { id = viewModel.EvaluationFormId });
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to update training directory.";
                    }
                }

                // Nếu dữ liệu không hợp lệ hoặc cập nhật không thành công, hiển thị lại view với view model hiện tại và lỗi
                return View(viewModel);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the training directory.");
                return View(viewModel);
            }
        }

        public async Task<IActionResult> DeleteTrainingDirectory(int id)
        {
            try
            {
                var trainingDirectoryToDelete = await _trainingDirectoryService.GetTrainingDirectoryByIdAsync(id);

                if (trainingDirectoryToDelete == null)
                {
                    return NotFound();
                }

                var deletedTrainingDirectory = await _trainingDirectoryService.DeleteTrainingDirectoryAsync(trainingDirectoryToDelete);

                if (deletedTrainingDirectory != null)
                {
                    // Chuyển hướng người dùng đến trang chi tiết của phiếu đánh giá
                    return RedirectToAction("EvaluationFormDetail", new { id = deletedTrainingDirectory.EvaluationFormId });
                }
                else
                {
                    // Xử lý khi xóa không thành công
                    TempData["ErrorMessage"] = "Failed to delete training directory.";
                    return RedirectToAction("EvaluationFormDetail", new { id = trainingDirectoryToDelete.EvaluationFormId });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Create, Update, Delete TrainingContent
        public IActionResult CreateTrainingContent(int trainingDirectoryId)
        {
            var viewModel = new TrainingContentViewModel
            {
                TrainingDirectoryId = trainingDirectoryId
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingContent(TrainingContentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var maxOrder = await _trainingContentService.GetMaxOrderAsync();

                    if (viewModel.Order > maxOrder)
                    {
                        viewModel.Order = maxOrder + 1;
                    }

                    var trainingContent = viewModel.ToTrainingContent();

                    var createdTrainingContent = await _trainingContentService.CreateTrainingContentAsync(trainingContent);

                    if (createdTrainingContent != null)
                    {
                        return RedirectToAction("EvaluationFormDetail", new { id = viewModel.TrainingDirectoryId });
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to create training content.";
                        return RedirectToAction("CreateTrainingContent", new { trainingDirectoryId = viewModel.TrainingDirectoryId });
                    }
                }
                else
                {
                    return View(viewModel);
                }
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }
        #endregion
    }
}
