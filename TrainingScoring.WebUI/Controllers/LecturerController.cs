using Microsoft.AspNetCore.Mvc;

namespace TrainingScoring.WebUI.Controllers
{
    public class LecturerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
