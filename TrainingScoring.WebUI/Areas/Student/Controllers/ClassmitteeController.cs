using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = $"{WebUserRoles.Classmittee}")]
    public class ClassmitteeController : Controller
    {
        private readonly TrainingScoingDBContext _context;

        public ClassmitteeController(TrainingScoingDBContext context)
        {
            _context = context;
        }

        private async Task SetClassmitteeViewData()
        {
            var selectedSemester = HttpContext.Session.GetString("SelectedSemester");
            var selectedAcademicYear = HttpContext.Session.GetString("SelectedAcademicYearName");

            var userData = User.GetUserData();
            var student = await _context.Students
                                        .Include(s => s.Grade)
                                        .FirstOrDefaultAsync(s => s.StudentCode == userData.UserName);
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

            selectedSemester = HomeController.SemesterMapper.MapToNumber(selectedSemester);

            ViewBag.SelectedSemester = selectedSemester;
            ViewBag.SelectedAcademicYear = selectedAcademicYear;
            ViewBag.SelectedGrade = grade.Course.CourseName;
            ViewBag.SelectedMajor = grade.Major.MajorName;
        }

        public async Task<IActionResult> StudentOfClass()
        {
            await SetClassmitteeViewData();

            var userData = User.GetUserData();
            var student = await _context.Students
                                        .Include(s => s.Grade)
                                        .FirstOrDefaultAsync(s => s.StudentCode == userData.UserName);
            if (student == null)
            {
                return NotFound();
            }

            var studentsInGrade = await _context.Students
                                                .Where(s => s.GradeId == student.GradeId)
                                                .ToListAsync();

            return View(studentsInGrade);
        }

        public async Task<IActionResult> PointOfStudent()
        {
            var selectedSemester = HttpContext.Session.GetString("SelectedSemester");
            var selectedAcademicYearId = HttpContext.Session.GetInt32("SelectedAcademicYearId");

            if (string.IsNullOrEmpty(selectedSemester) || selectedAcademicYearId == null)
            {
                return RedirectToAction("SelectSemester", "Home", new { area = "Student" });
            }

            await SetClassmitteeViewData();

            var userData = User.GetUserData();
            var student = await _context.Students
                                        .Include(s => s.Grade)
                                        .FirstOrDefaultAsync(s => s.StudentCode == userData.UserName);
            if (student == null)
            {
                return NotFound();
            }

            var studentsInGrade = await _context.Students
                                                .Where(s => s.GradeId == student.GradeId)
                                                .ToListAsync();

            return View(studentsInGrade);
        }
    }
}
