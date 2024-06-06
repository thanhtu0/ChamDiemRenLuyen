using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{WebUserRoles.Advisor}")]
    public class AdvisorController : Controller
    {
        public IActionResult SetClassmittee()
        {
            return View();
        }

        public IActionResult StudentListAdvisor()
        {
            return View();
        }

        public IActionResult StudentPointAdvisor()
        {
            return View();
        }
    }
}
