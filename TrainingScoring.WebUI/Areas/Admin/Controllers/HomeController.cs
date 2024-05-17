using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{WebUserRoles.Advisor}, {WebUserRoles.Department}, {WebUserRoles.School}, {WebUserRoles.SuperAdmin}")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
