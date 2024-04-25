using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Models;

namespace KhumaloCraft.Controllers
{
    public class UserController : Controller
    {
        public userTBL usertbl = new userTBL();

        [HttpPost]
        public ActionResult About(userTBL Users)
        {
            var result = usertbl.insert_User(Users);
            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            return View(usertbl);
        }

        public IActionResult Order()
        {
            return View();
        }

    }
}
