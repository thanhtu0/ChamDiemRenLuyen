using Microsoft.AspNetCore.Mvc;

namespace ChamDiemRenLuyen.WebUI.Controllers
{
    public class LecturerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
