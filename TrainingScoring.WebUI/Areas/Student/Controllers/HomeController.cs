using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrainingScoring.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        public IActionResult IndexForStudent()
        {
            return View();
        }

        public IActionResult IndexForClassmittee()
        {
            return View();
        }
    }
}
