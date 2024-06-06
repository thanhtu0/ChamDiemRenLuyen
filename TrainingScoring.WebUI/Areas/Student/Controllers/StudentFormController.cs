using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data;
using TrainingScoring.DomainModels;
using TrainingScoring.WebUI.Models;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = $"{WebUserRoles.Student}, {WebUserRoles.Classmittee}")]
    public class StudentFormController : Controller
    {
        private readonly TrainingScoingDBContext _context;
        private readonly ILogger<StudentFormController> _logger;
        private readonly IUserService _userService;
        private readonly IAcademicYearService _academicYearService;
        private readonly IEvaluationFormService _evaluationFormService;
        private readonly ITrainingDirectoryService _trainingDirectoryService;
        private readonly ITrainingContentService _trainingContentService;
        private readonly ITrainingDetailService _trainingDetailService;
        private readonly IStudentScoreService _studentScoreService;

        public StudentFormController(TrainingScoingDBContext context, 
            ILogger<StudentFormController> logger,
            IUserService userService, 
            IAcademicYearService academicYearService, 
            IEvaluationFormService evaluationFormService, 
            ITrainingDirectoryService trainingDirectoryService, 
            ITrainingContentService trainingContentService, 
            ITrainingDetailService trainingDetailService, 
            IStudentScoreService studentScoreService)
        {
            _context = context;
            _logger = logger;
            _userService = userService;
            _academicYearService = academicYearService;
            _evaluationFormService = evaluationFormService;
            _trainingDirectoryService = trainingDirectoryService;
            _trainingContentService = trainingContentService;
            _trainingDetailService = trainingDetailService;
            _studentScoreService = studentScoreService;
        }

        public async Task<IActionResult> StudentForm()
        {
            var selectedSemester = HttpContext.Session.GetString("SelectedSemester");
            var selectedAcademicYearId = HttpContext.Session.GetInt32("SelectedAcademicYearId");

            if (string.IsNullOrEmpty(selectedSemester) || selectedAcademicYearId == null)
            {
                return RedirectToAction("SelectSemester", "Home", new { area = "Student" });
            }

            await SetClassmitteeViewData();

            try
            {
                _logger.LogInformation($"Selected Academic Year ID: {selectedAcademicYearId.Value}");
                var evaluationForm = await _evaluationFormService.GetEvaluationFormsByAcademicYearIdAsync(selectedAcademicYearId.Value);

                if (evaluationForm == null)
                {
                    _logger.LogWarning("Không tìm thấy phiếu đánh giá cho học kỳ và năm học đã chọn.");
                    TempData["ErrorMessage"] = "Không tìm thấy phiếu đánh giá cho học kỳ và năm học đã chọn.";
                    return View();
                }

                List<TrainingDirectory> trainingDirectories = await _trainingDirectoryService.GetAllTrainingDirectoryByEFormId(evaluationForm.EvaluationFormId);

                if (trainingDirectories == null || !trainingDirectories.Any())
                {
                    trainingDirectories = new List<TrainingDirectory>();
                }

                List<TrainingContent> trainingContents = await _trainingContentService.GetAllTrainingContentsAsync();
                List<TrainingDetail> trainingDetails = await _trainingDetailService.GetAllTrainingDetailsAsync();

                var studentFormVM = new StudentFormViewModel()
                {
                    EvaluationFormId = evaluationForm.EvaluationFormId,
                    EvaluationFormCode = evaluationForm.EvaluationFormCode,
                    EvaluationFormName = evaluationForm.EvaluationFormName,
                    TrainingDirectories = trainingDirectories,
                    TrainingContents = trainingContents,
                    TrainingDetails = trainingDetails
                };

                return View(studentFormVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        public async Task<IActionResult> SaveScore(StudentFormViewModel viewModel)
        {
            return View();
        }

        public async Task<IActionResult> UpdateScore()
        {
            return View();
        }

        public async Task<IActionResult> SubmitScore()
        {
            return View();
        }

        public async Task<IActionResult> RankingOfStudent(SemesterSelectionViewModel model)
        {
            var selectedSemester = HttpContext.Session.GetString("SelectedSemester");
            var selectedAcademicYearId = HttpContext.Session.GetInt32("SelectedAcademicYearId");

            if (string.IsNullOrEmpty(selectedSemester) || selectedAcademicYearId == null)
            {
                return RedirectToAction("SelectSemester", "Home", new { area = "Student" });
            }

            await SetClassmitteeViewData();

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
                                      .Include(g => g.GradeLecturerAssignments)
                                        .ThenInclude(gla => gla.Lecturer)
                                      .FirstOrDefaultAsync(g => g.GradeId == student.GradeId);

            if (grade == null)
            {
                return NotFound();
            }

            var lecturers = grade.GradeLecturerAssignments.Select(gla => gla.Lecturer).ToList();
            var lecturerNames = lecturers.Select(l => $"{l.FirstName} {l.LastName}").ToList();

            int startYear = int.Parse(grade.Course.StartYear);
            int endYear = int.Parse(grade.Course.EndYear);

            var academicYears = await _context.AcademicYears.ToListAsync();
            var filteredAcademicYears = new List<SemesterSelectionViewModel.AcademicYearViewModel>();

            foreach (var ay in academicYears.Where(ay => int.Parse(ay.AcademicYearName.Split('-')[0]) >= startYear && int.Parse(ay.AcademicYearName.Split('-')[1]) <= endYear))
            {
                var score = await _studentScoreService.GetScoreAsync(student.StudentId, ay.AcademicYearId);
                var academicYearVM = new SemesterSelectionViewModel.AcademicYearViewModel
                {
                    AcademicYearId = ay.AcademicYearId,
                    Semester = ay.Semester.ToString(),
                    AcademicYearName = ay.AcademicYearName,
                    Course = $"{grade.Course.CourseName}",
                    Major = $"{grade.Major.MajorName}",
                    Grade = grade.GradeName,
                    SemesterCode = ay.SemesterCode,
                    LecturerNames = lecturerNames,
                    Score = score?.TotalScore,
                    Ranking = score?.Ranking
                };
                filteredAcademicYears.Add(academicYearVM);
            }

            model.AcademicYears = filteredAcademicYears;

            return View(model);
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
    }
}
