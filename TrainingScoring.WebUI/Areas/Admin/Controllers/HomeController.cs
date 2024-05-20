using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{WebUserRoles.Advisor}, {WebUserRoles.Department}, {WebUserRoles.School}, {WebUserRoles.SuperAdmin}")]

    public class HomeController : Controller
    {
        private readonly TrainingScoingDBContext _contenxt;
        private readonly ILogger<EvaluationFormController> _logger;
        private readonly IUserService _userService;

        public HomeController(TrainingScoingDBContext contenxt,
            ILogger<EvaluationFormController> logger,
            IUserService userService)
        {
            _contenxt = contenxt;
            _logger = logger;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var userData = User.GetUserData();
            var admin = await _userService.GetLecturerByCodeAsync(userData.UserName);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }
    }
}
