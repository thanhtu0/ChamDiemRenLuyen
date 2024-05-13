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

        public EvaluationFormController(ILogger<SystemmanagementController> logger,
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
                    EvvaluationFormCode = evaluationForms.EvaluationFormCode,
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
    }
}
