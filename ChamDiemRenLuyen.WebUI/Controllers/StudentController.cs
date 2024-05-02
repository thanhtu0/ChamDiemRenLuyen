using Microsoft.AspNetCore.Mvc;

namespace ChamDiemRenLuyen.WebUI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
