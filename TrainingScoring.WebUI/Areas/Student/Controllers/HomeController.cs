using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingScoring.WebUI.Models;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = $"{WebUserRoles.Student}, {WebUserRoles.Classmittee}")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
