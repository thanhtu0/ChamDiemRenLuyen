using Microsoft.AspNetCore.Mvc;

namespace TrainingScoring.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
