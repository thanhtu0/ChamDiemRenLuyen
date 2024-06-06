using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data;
using TrainingScoring.WebUI.AppCodes;
using TrainingScoring.WebUI.Models;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = $"{WebUserRoles.Student}, {WebUserRoles.Classmittee}")]
    public class HomeController : Controller
    {
        private readonly TrainingScoingDBContext _context;
        private readonly ILogger<StudentFormController> _logger;
        private readonly IUserService _userService;

        public HomeController(
            TrainingScoingDBContext context,
            ILogger<StudentFormController> logger,
            IUserService userService)
        {
            _context = context;
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var selectedSemester = HttpContext.Session.GetString("SelectedSemester");
            var selectedAcademicYear = HttpContext.Session.GetString("SelectedAcademicYearName");

            if (string.IsNullOrEmpty(selectedSemester) || string.IsNullOrEmpty(selectedAcademicYear))
            {
                return RedirectToAction("SelectSemester");
            }

            await SetStudentViewData();
            return View();
        }

        /// <summary>
        /// Show Information Student
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Profile()
        {
            await SetStudentViewData();
            var userData = User.GetUserData();
            var student = await _userService.GetStudentByCodeAsync(userData.UserName);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        #region SelectSemester
        [HttpGet]
        public async Task<IActionResult> SelectSemester()
        {
            var userData = User.GetUserData();
            var student = await _userService.GetStudentByCodeAsync(userData.UserName);

            if (student == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                                      .Include(g => g.Course)
                                      .Include(g => g.Major)
                                      .FirstOrDefaultAsync(g => g.GradeId == student.GradeId);

            if (grade == null)
            {
                return NotFound();
            }

            int startYear = int.Parse(grade.Course.StartYear);
            int endYear = int.Parse(grade.Course.EndYear);

            var academicYears = await _context.AcademicYears.ToListAsync();
            var filteredAcademicYears = academicYears
                .Where(ay =>
                    int.Parse(ay.AcademicYearName.Split('-')[0]) >= startYear &&
                    int.Parse(ay.AcademicYearName.Split('-')[1]) <= endYear)
                .Select(ay => new SemesterSelectionViewModel.AcademicYearViewModel
                {
                    AcademicYearId = ay.AcademicYearId,
                    Semester = ay.Semester.ToString(),
                    AcademicYearName = ay.AcademicYearName,
                    Course = $"{grade.Course.CourseName}",
                    Major = $"{grade.Major.MajorName}",
                    Grade = grade.GradeName,
                    SemesterCode = ay.SemesterCode
                }).ToList();

            var model = new SemesterSelectionViewModel
            {
                AcademicYears = filteredAcademicYears
            };

            var selectedSemester = HttpContext.Session.GetString("SelectedSemester");
            var selectedAcademicYear = HttpContext.Session.GetString("SelectedAcademicYearName");
            selectedSemester = SemesterMapper.MapToNumber(selectedSemester);

            ViewBag.SelectedSemester = selectedSemester;
            ViewBag.SelectedAcademicYear = selectedAcademicYear;
            ViewBag.SelectedGrade = grade.Course.CourseName;
            ViewBag.SelectedMajor = grade.Major.MajorName;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SelectSemester(SemesterSelectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var selectedAcademicYear = await _context.AcademicYears.FindAsync(model.SelectedAcademicYearId);
                if (selectedAcademicYear != null)
                {
                    HttpContext.Session.SetInt32("SelectedAcademicYearId", selectedAcademicYear.AcademicYearId);
                    HttpContext.Session.SetString("SelectedSemester", selectedAcademicYear.Semester.ToString());
                    HttpContext.Session.SetString("SelectedAcademicYearName", selectedAcademicYear.AcademicYearName);

                    return RedirectToAction("Index", "Home", new { area = "Student" });
                }
                else
                {
                    ModelState.AddModelError("", "Học kỳ được chọn không hợp lệ.");
                }
            }

            var userData = User.GetUserData();
            var student = await _userService.GetStudentByCodeAsync(userData.UserName);

            if (student == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                                      .Include(g => g.Course)
                                      .Include(g => g.Major)
                                      .FirstOrDefaultAsync(g => g.GradeId == student.GradeId);

            if (grade == null)
            {
                return NotFound();
            }

            int startYear = int.Parse(grade.Course.StartYear);
            int endYear = int.Parse(grade.Course.EndYear);

            var academicYears = await _context.AcademicYears.ToListAsync();
            var filteredAcademicYears = academicYears
                .Where(ay =>
                    int.Parse(ay.AcademicYearName.Split('-')[0]) >= startYear &&
                    int.Parse(ay.AcademicYearName.Split('-')[1]) <= endYear)
                .Select(ay => new SemesterSelectionViewModel.AcademicYearViewModel
                {
                    AcademicYearId = ay.AcademicYearId,
                    Semester = ay.Semester.ToString(),
                    AcademicYearName = ay.AcademicYearName,
                    Course = $"{grade.Course.CourseName}",
                    Major = $"{grade.Major.MajorName}",
                    Grade = grade.GradeName,
                    SemesterCode = ay.SemesterCode
                }).ToList();

            model.AcademicYears = filteredAcademicYears;

            return View(model);
        }
        #endregion

        #region ChangePassword
        public async Task<IActionResult> ChangePassword()
        {
            await SetStudentViewData();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Thông tin không hợp lệ.");
                return View(model);
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu mới không tương khớp. Đổi mật khẩu thất bại.");
                return View(model);
            }

            var userData = User.GetUserData();
            var result = await _userService.ChangePasswordAsync(userData.UserName, model.OldPassword, model.NewPassword);

            switch (result)
            {
                case "invalid_old_password":
                    ModelState.AddModelError(string.Empty, "Sai mật khẩu cũ. Đổi mật khẩu thất bại.");
                    break;
                case "new_password_same_as_old":
                    ModelState.AddModelError(string.Empty, "Giống mật khẩu cũ. Đổi mật khẩu thất bại.");
                    break;
                case "success":
                    TempData["SuccessMessage"] = "Đổi mật khẩu thành công.";
                    return RedirectToAction("Index");
                default:
                    ModelState.AddModelError(string.Empty, "Đổi mật khẩu thất bại.");
                    break;
            }

            return View(model);
        }
        #endregion

        public static class SemesterMapper
        {
            public static string MapToNumber(string semester)
            {
                if (semester == "First")
                {
                    return "1";
                }
                else if (semester == "Second")
                {
                    return "2";
                }
                return semester;
            }
        }

        private async Task SetStudentViewData()
        {
            var selectedSemester = HttpContext.Session.GetString("SelectedSemester");
            var selectedAcademicYear = HttpContext.Session.GetString("SelectedAcademicYearName");

            var userData = User.GetUserData();
            var student = await _userService.GetStudentByCodeAsync(userData.UserName);
            if (student == null)
            {
                throw new InvalidOperationException("Student not found.");
            }

            var grade = await _context.Grades
                                  .Include(g => g.Course)
                                  .Include(g => g.Major)
                                  .FirstOrDefaultAsync(g => g.GradeId == student.GradeId);
            if (grade == null)
            {
                throw new InvalidOperationException("Grade not found.");
            }

            selectedSemester = SemesterMapper.MapToNumber(selectedSemester);

            ViewBag.SelectedSemester = selectedSemester;
            ViewBag.SelectedAcademicYear = selectedAcademicYear;
            ViewBag.SelectedGrade = grade.Course.CourseName;
            ViewBag.SelectedMajor = grade.Major.MajorName;
        }
    }
}