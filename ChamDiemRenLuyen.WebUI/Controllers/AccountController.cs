using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ChamDiemRenLuyen.WebUI.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Giao diện trang đăng nhập
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
