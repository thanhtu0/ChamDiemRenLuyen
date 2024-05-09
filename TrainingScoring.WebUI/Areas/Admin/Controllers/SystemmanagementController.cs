using Microsoft.AspNetCore.Mvc;
using TrainingScoring.Business.Services.Implementations;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data.Repositories.Interfaces;
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
                var evaluationForms = await _evaluationFormService.GetEvaluationFormsAsync();
                var trainingDirectories = await _trainingDirectoryService.GetTrainingDirectoriesAsync();
                var trainingContents = await _trainingContentService.GetTrainingContentsAsync();
                var trainingDetails = await _trainingDetailService.GetTrainingDetailsAsync();
                return View(evaluationForms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
