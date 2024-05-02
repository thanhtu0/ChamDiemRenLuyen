using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TrainingScoring.Business;

namespace TrainingScoring.WebUI.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IUserRepository _repo;

        public AccountController(IUserRepository repo )
        {
            _repo = repo;
        }
        /// <summary>
        /// Giao diện trang đăng nhập
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            _repo.DeleteAsync(1);
            return View();
        }

        
    }
}
