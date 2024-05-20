using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data;
using TrainingScoring.DomainModels;
using TrainingScoring.WebUI.Areas.Admin.Controllers;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = $"{WebUserRoles.Student}, {WebUserRoles.Classmittee}")]
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
            var student = await _userService.GetStudentByCodeAsync(userData.UserName);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
