using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;
namespace KhumaloCraft.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel login;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            login = new LoginModel();
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost]
        public ActionResult Privacy(string email, string name)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.SelectUser(email, name);
            if (userID != -1)
            {
                //Store user ID section
                HttpContext.Session.SetInt32("userID", userID);
                //
               // return RedirectToAction("Index", "Home", new { userID = userID });
               return RedirectToAction("Index", "Home");
            }
            else
            {
                //
                return View("LoginFailed");
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("userID");
            return RedirectToAction("Privacy","Home");
        
        }

        public IActionResult Privacy()
        {
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("userID");
            if (userID == null)
            {
                ViewData["userID"] = 0;
            }
            else
            {
                ViewData["userID"] = userID;
            }

            return View();
        }
    }
}
