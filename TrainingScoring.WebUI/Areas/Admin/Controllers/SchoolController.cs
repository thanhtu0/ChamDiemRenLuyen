using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data;
using TrainingScoring.WebUI.AppCodes;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{WebUserRoles.School}")]
    public class SchoolController : Controller
    {
        private readonly TrainingScoingDBContext _context;

        public SchoolController(TrainingScoingDBContext context)
        {
            _context = context;
        }

        public IActionResult DepartmentList()
        {
            return View();
        }

        public IActionResult GradeListDepartment()
        {
            return View();
        }

        public IActionResult StudentPointDepartment()
        {
            return View();
        }
    }
}
