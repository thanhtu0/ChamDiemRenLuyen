using Microsoft.AspNetCore.Mvc;

namespace TrainingScoring.WebUI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
