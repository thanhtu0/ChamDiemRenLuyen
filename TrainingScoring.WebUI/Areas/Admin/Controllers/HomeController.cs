using Microsoft.AspNetCore.Mvc;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult IndexForAdvisor()
        {
            return View();
        }

        public IActionResult IndexForDepartment()
        {
            return View();
        }

        public IActionResult IndexForSchool()
        {
            return View();
        }

        public IActionResult IndexForSuperAdmin()
        {
            return View();
        }
    }
}
