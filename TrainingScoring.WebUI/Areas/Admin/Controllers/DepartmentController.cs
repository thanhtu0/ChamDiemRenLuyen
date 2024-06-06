using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{WebUserRoles.Department}")]
    public class DepartmentController : Controller
    {
        public IActionResult StudentListDepartment()
        {
            return View();
        }

        public IActionResult StudentPointDepartment()
        {
            return View();
        }
    }
}
