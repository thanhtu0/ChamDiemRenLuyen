using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data;
using TrainingScoring.DomainModels;
using TrainingScoring.WebUI.Models;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EvaluationFormController : Controller
    {
        private readonly TrainingScoingDBContext _contenxt;
        private readonly ILogger<EvaluationFormController> _logger;
        private readonly IEvaluationFormService _evaluationFormService;

        private readonly ITrainingDirectoryService _trainingDirectoryService;
        private readonly ITrainingContentService _trainingContentService;
        private readonly ITrainingDetailService _trainingDetailService;
        private readonly IAcademicYearService _academicYearService;

        public EvaluationFormController(
            TrainingScoingDBContext _context,
            ILogger<EvaluationFormController> logger,
            IEvaluationFormService evaluationFormService,
            ITrainingDirectoryService trainingDirectoryService,
            ITrainingContentService trainingContentService,
            ITrainingDetailService trainingDetailService,
            IAcademicYearService academicYearService)
        {
            _contenxt = _context;
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
                    // Lấy thông tin của danh mục rèn luyện cần cập nhật
                    var trainingDirectory = await _trainingDirectoryService.GetTrainingDirectoryByIdAsync(viewModel.TrainingDirectoryId);

                    if (trainingDirectory == null)
                    {
                        return NotFound();
                    }

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
        public IActionResult CreateTrainingContent(int trainingDirectoryId, int evaluationFormId)
        {
            _logger.LogInformation($"EvaluationFormId:{evaluationFormId} TrainingDirectoryId:{trainingDirectoryId}");
            var viewModel = new TrainingContentViewModel
            {
                TrainingDirectoryId = trainingDirectoryId,
                EvaluationFormId = evaluationFormId
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingContent(TrainingContentViewModel viewModel)
        {
            _logger.LogInformation(
                $"IsProof value: {viewModel.IsProof}" +
                $"EvaluationFormId:{viewModel.EvaluationFormId} " +
                $"TrainingDirectoryId:{viewModel.TrainingDirectoryId}" +
                $"Order: {viewModel.Order}" +
                $"TrainingContentName: {viewModel.TrainingContentName}" +
                $"MaxScore: {viewModel.MaxScore}" +
                $"TypeofScore: {viewModel.TypeofScore}"
                );

            try
            {
                if (ModelState.IsValid)
                {
                    var maxOrder = await _trainingContentService.GetMaxOrderAsync(viewModel.TrainingDirectoryId);

                    if (viewModel.Order > maxOrder)
                    {
                        viewModel.Order = maxOrder + 1;
                    }

                    var trainingContent = viewModel.ToTrainingContent();

                    var createdTrainingContent = await _trainingContentService.CreateTrainingContentAsync(trainingContent);

                    if (createdTrainingContent != null)
                    {
                        return RedirectToAction("EvaluationFormDetail", "EvaluationForm", new { id = viewModel.EvaluationFormId });
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to create training content.";
                        return RedirectToAction("CreateTrainingContent", new { trainingDirectoryId = viewModel.TrainingDirectoryId, evaluationFormId = viewModel.EvaluationFormId });
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
                TempData["ErrorMessage"] = "An error occurred while creating the training content.";
                return RedirectToAction("CreateTrainingContent", new { trainingDirectoryId = viewModel.TrainingDirectoryId, evaluationFormId = viewModel.EvaluationFormId });
            }
        }

        public async Task<IActionResult> UpdateTrainingContent(int id, int trainingDirectoryId, int evaluationFormId)
        {
            try
            {
                _logger.LogInformation($"Fetching training content with id: {id}");
                var trainingContent = await _trainingContentService.GetTrainingContentByIdAsync(id);

                if (trainingContent == null)
                {
                    _logger.LogWarning($"Training content with id {id} not found.");
                    return NotFound();
                }

                var viewModel = new TrainingContentViewModel
                {
                    TrainingContentId = trainingContent.TrainingContentId,
                    TrainingDirectoryId = trainingContent.TrainingDirectoryId,
                    TrainingContentName = trainingContent.TrainingContentName,
                    Order = trainingContent.Order,
                    IsProof = trainingContent.IsProof,
                    MaxScore = trainingContent.MaxScore,
                    TypeofScore = trainingContent.TypeofScore,
                    CreateAt = trainingContent.CreateAt,
                    DeletedAt = trainingContent.DeletedAt,
                    EvaluationFormId = evaluationFormId // Sử dụng giá trị evaluationFormId được chuyển từ action
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
        public async Task<IActionResult> UpdateTrainingContent(TrainingContentViewModel viewModel, int trainingDirectoryId, int evaluationFormId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedTrainingContent = await _trainingContentService.UpdateTrainingContentAsync(viewModel.ToTrainingContent());

                    if (updatedTrainingContent != null)
                    {
                        return RedirectToAction("EvaluationFormDetail", "EvaluationForm", new { id = evaluationFormId });
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to update training content.";
                    }
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the training content.");
                return View(viewModel);
            }
        }

        public async Task<IActionResult> DeleteTrainingContent(int id, int trainingDirectoryId, int evaluationFormId)
        {
            try
            {
                var trainingContentToDelete = await _trainingContentService.GetTrainingContentByIdAsync(id);

                if (trainingContentToDelete == null)
                {
                    return NotFound();
                }

                var deletedTrainingContent = await _trainingContentService.DeleteTrainingContentAsync(trainingContentToDelete);

                if (deletedTrainingContent != null && deletedTrainingContent.TrainingDirectory != null)
                {
                    // Xóa thành công, chuyển hướng đến trang chi tiết của phiếu đánh giá
                    return RedirectToAction("EvaluationFormDetail", new { id = evaluationFormId });
                }
                else
                {
                    // Xóa không thành công, đặt thông báo lỗi và chuyển hướng
                    TempData["ErrorMessage"] = "Failed to delete training content.";
                    return RedirectToAction("EvaluationFormDetail", new { id = evaluationFormId });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        #endregion

        #region Create, Update, Delete TrainingDetail
        public IActionResult CreateTrainingDetail(int trainingContentId, int trainingDirectoryId, int evaluationFormId)
        {
            _logger.LogInformation(
                $"EvaluationFormId:{evaluationFormId} " +
                $"TrainingDirectoryId:{trainingDirectoryId}" +
                $"TrainingContentId: {trainingContentId}"
                );

            var viewModel = new TrainingDetailViewModel
            {
                TrainingContentId = trainingContentId,
                TrainingDirectoryId = trainingDirectoryId,
                EvaluationFormId = evaluationFormId,

            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingDetail(TrainingDetailViewModel viewModel)
        {
            _logger.LogInformation(
                $"IsProof value: {viewModel.IsProof}" +
                $"EvaluationFormId:{viewModel.EvaluationFormId} " +
                $"TrainingDirectoryId:{viewModel.TrainingDirectoryId}" +
                $"TrainingContentId:{viewModel.TrainingContentId}" +
                $"Order: {viewModel.Order}" +
                $"TrainingDetailName: {viewModel.TrainingDetailName}" +
                $"MaxScore: {viewModel.MaxScore}" +
                $"TypeofScore: {viewModel.TypeofScore}"
                );

            try
            {
                if (ModelState.IsValid)
                {
                    var maxOrder = await _trainingDetailService.GetMaxOrderAsync(viewModel.TrainingContentId);

                    if (viewModel.Order > maxOrder)
                    {
                        viewModel.Order = maxOrder + 1;
                    }

                    var trainingDetaiil = viewModel.ToTrainingDetail();

                    var createdTrainingDetail = await _trainingDetailService.CreateTrainingDetailAsync(trainingDetaiil);

                    if (createdTrainingDetail != null)
                    {
                        return RedirectToAction("EvaluationFormDetail", "EvaluationForm", new { id = viewModel.EvaluationFormId });
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to create training content.";
                        return RedirectToAction("CreateTrainingContent", new
                        {
                            trainingContentId = viewModel.TrainingContentId,
                            trainingDirectoryId = viewModel.TrainingDirectoryId,
                            evaluationFormId = viewModel.EvaluationFormId
                        }
                        );
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
                TempData["ErrorMessage"] = "An error occurred while creating the training content.";
                return RedirectToAction("CreateTrainingContent", new
                {
                    trainingContentId = viewModel.TrainingContentId,
                    trainingDirectoryId = viewModel.TrainingDirectoryId,
                    evaluationFormId = viewModel.EvaluationFormId
                });
            }
        }

        public async Task<IActionResult> UpdateTrainingDetail(int id, int trainingContentId, int trainingDirectoryId, int evaluationFormId)
        {
            try
            {
                _logger.LogInformation($"Fetching training detail with id: {id}");
                var trainingDetail = await _trainingDetailService.GetTrainingDetailByIdAsync(id);

                if (trainingDetail == null)
                {
                    _logger.LogWarning($"Training detail with id {id} not found.");
                    return NotFound();
                }

                var viewModel = new TrainingDetailViewModel
                {
                    TrainingDetailId = trainingDetail.TrainingDetailId,
                    TrainingContentId = trainingDetail.TrainingContentId,
                    TrainingDetailName = trainingDetail.TrainingDetailName,
                    Order = trainingDetail.Order,
                    IsProof = trainingDetail.IsProof,
                    MaxScore = trainingDetail.MaxScore,
                    TypeofScore = trainingDetail.TypeofScore,
                    CreateAt = trainingDetail.CreateAt,
                    DeletedAt = trainingDetail.DeletedAt,
                    EvaluationFormId = evaluationFormId 
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
        public async Task<IActionResult> UpdateTrainingDetail(TrainingDetailViewModel viewModel, int trainingContentId, int trainingDirectoryId, int evaluationFormId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedTrainingDetail = await _trainingDetailService.UpdateTrainingDetailAsync(viewModel.ToTrainingDetail());

                    if (updatedTrainingDetail != null)
                    {
                        return RedirectToAction("EvaluationFormDetail", "EvaluationForm", new { id = evaluationFormId });
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to update training detail.";
                    }
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the training detail.");
                return View(viewModel);
            }
        }

        public async Task<IActionResult> DeleteTrainingDetail(int id, int trainingContentId, int trainingDirectoryId, int evaluationFormId)
        {
            try
            {
                var trainingDetailToDelete = await _trainingDetailService.GetTrainingDetailByIdAsync(id);

                if (trainingDetailToDelete == null)
                {
                    return NotFound();
                }

                var deletedTrainingDetail = await _trainingDetailService.DeleteTrainingDetailAsync(trainingDetailToDelete);

                if (deletedTrainingDetail != null && deletedTrainingDetail.TrainingContent != null)
                {
                    // Xóa thành công, chuyển hướng đến trang chi tiết của phiếu đánh giá
                    return RedirectToAction("EvaluationFormDetail", new { id = evaluationFormId });
                }
                else
                {
                    // Xóa không thành công, đặt thông báo lỗi và chuyển hướng
                    TempData["ErrorMessage"] = "Failed to delete training content.";
                    return RedirectToAction("EvaluationFormDetail", new { id = evaluationFormId });
                }
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
