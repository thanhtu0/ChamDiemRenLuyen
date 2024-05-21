using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data;
using TrainingScoring.WebUI.Models;
using static TrainingScoring.WebUI.AppCodes.SecurityModels;

namespace TrainingScoring.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{WebUserRoles.Advisor}, {WebUserRoles.Department}, {WebUserRoles.School}, {WebUserRoles.SuperAdmin}")]

    public class HomeController : Controller
    {
        private readonly TrainingScoingDBContext _contenxt;
        private readonly ILogger<EvaluationFormController> _logger;
        private readonly IUserService _userService;

        public HomeController(
            TrainingScoingDBContext contenxt,
            ILogger<EvaluationFormController> logger,
            IUserService userService)
        {
            _contenxt = contenxt;
            _logger = logger;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var userData = User.GetUserData();
            var lecturer = await _userService.GetLecturerByCodeAsync(userData.UserName);
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }

        public IActionResult ChangePassword()
        {
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


    }
}
