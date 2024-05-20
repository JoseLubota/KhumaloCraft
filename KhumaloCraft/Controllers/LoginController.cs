using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;
namespace KhumaloCraft.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel login;
        public LoginController()
        {
            login = new LoginModel();
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
    }
}
