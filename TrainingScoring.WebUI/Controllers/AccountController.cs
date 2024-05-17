using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data;
using TrainingScoring.DomainModels;
using TrainingScoring.WebUI.Areas.Admin.Controllers;
using TrainingScoring.WebUI.Models;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly TrainingScoingDBContext _contenxt;
        private readonly ILogger<EvaluationFormController> _logger;
        private readonly IUserService _userService;

        public AccountController(TrainingScoingDBContext contenxt,
            ILogger<EvaluationFormController> logger,
            IUserService userService)
        {
            _contenxt = contenxt;
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không chính xác.");
                return View(model);
            }


            var user = await _userService.LoginAsync(model.Code, model.Password);
            _logger.LogInformation($"user code service - controller: {user}");
            var userRoles = await _userService.GetUserRolesAsync(user);
            _logger.LogInformation($"user role service2222: {userRoles}");
            List<string> roleForLecturer = new List<string>();
            foreach (var rr in userRoles)
            {
                _logger.LogInformation($"user role list service: {rr}");
                roleForLecturer.Add(rr.ToString());
            }
            if (userRoles.Count() >= 1)
            {
                var lecturer = await _userService.GetLecturerAsync(user);

                _logger.LogInformation($"user teacher: {lecturer.LecturerCode}");
                _logger.LogInformation($"user role list servic3333e: {roleForLecturer}");

                WebUserData userData = new WebUserData()
                {
                    UserId = lecturer.LecturerId.ToString(),
                    UserName = lecturer.LecturerCode,
                    DisplayName = lecturer.FirstName + " " + lecturer.LastName,
                    Email = lecturer.Email,
                    Photo = lecturer.Photo,
                    ClientIP = HttpContext.Connection.RemoteIpAddress?.ToString(),
                    SessionId = HttpContext.Session.Id,
                    AdditionalData = "",
                    Roles = roleForLecturer
                };
                //2. Thiết lập (ghi nhận) phiên đăng nhập
                await HttpContext.SignInAsync(userData.CreatePrincipal());

                return RedirectToAction("Index", "Home", new { area = "Admin" });
               
            }
            else
            {
                // khong co role la STudent
                var student = await _userService.GetStudentAsync(user);

                WebUserData userData = new WebUserData()
                {
                    UserId = student.StudentId.ToString(),
                    UserName = student.StudentCode,
                    DisplayName = student.FirstName + " " + student.LastName,
                    Email = student.Email,
                    Photo = student.Photo,
                    ClientIP = HttpContext.Connection.RemoteIpAddress?.ToString(),
                    SessionId = HttpContext.Session.Id,
                    AdditionalData = "",
                    Roles = new List<string>() { WebUserRoles.Student, student.IsClassmittee != Classmittee.Student ? WebUserRoles.Classmittee : "" }
                };
                //2. Thiết lập (ghi nhận) phiên đăng nhập
                await HttpContext.SignInAsync(userData.CreatePrincipal());

                return RedirectToAction("Index", "Home", new { area = "Student" });
            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }


    }
}
