using Microsoft.AspNetCore.Mvc;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemmanagementController : Controller
    {
        private readonly ILogger<SystemmanagementController> _logger;
        private readonly IEvaluationFormService _evaluationFormService;

        private readonly ITrainingDirectoryService _trainingDirectoryService;
        private readonly ITrainingContentService _trainingContentService;
        private readonly ITrainingDetailService _trainingDetailService;

        public SystemmanagementController(ILogger<SystemmanagementController> logger,
            IEvaluationFormService evaluationFormService,
            ITrainingDirectoryService trainingDirectoryService,
            ITrainingContentService trainingContentService, 
            ITrainingDetailService trainingDetailService)
        {
            _logger = logger;
            _evaluationFormService = evaluationFormService;
            _trainingDirectoryService = trainingDirectoryService;
            _trainingContentService = trainingContentService;
            _trainingDetailService = trainingDetailService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var evaluationForms = await _evaluationFormService.GetAllEvaluationFormsAsync();
                var trainingDirectories = await _trainingDirectoryService.GetAllTrainingDirectoriesAsync();
                var trainingContents = await _trainingContentService.GetAllTrainingContentsAsync();
                var trainingDetails = await _trainingDetailService.GetAllTrainingDetailsAsync();
                return View(evaluationForms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        public async Task<IActionResult> IndexForm()
        {
            try
            {
                var evaluationForms = await _evaluationFormService.GetAllEvaluationFormsAsync();
                return View(evaluationForms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    try
        //    {
        //        var evaluationForm = await _evaluationFormService.GetEvaluationFormByIdAsync(id);
        //        var trainingDirectories = await _trainingDirectoryService.GetTrainingDirectoriesAsync();
        //        var trainingContents = await _trainingContentService.GetTrainingContentsAsync();
        //        var trainingDetails = await _trainingDetailService.GetTrainingDetailsAsync();

        //        var model = new EvaluationFormDetailsViewModel
        //        {
        //            EvaluationForm = evaluationForm,
        //            TrainingDirectories = trainingDirectories,
        //            TrainingContents = trainingContents,
        //            TrainingDetails = trainingDetails
        //        };

        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EvaluationForm evaluationForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdEvaluationForm = await _evaluationFormService.CreateEvaluationFormAsync(evaluationForm);
                    return RedirectToAction("Details", new { id = createdEvaluationForm.EvaluationFormId });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error creating evaluation form: {ex.Message}");
                    ModelState.AddModelError("", "An error occurred while creating the evaluation form.");
                }
            }
            return View(evaluationForm);
        }

    }
}
