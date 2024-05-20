using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
    public class OrderDisplayController : Controller
    {
        
        [HttpPost]
        public ActionResult Order(string name, string email, string surname)
        {
            List<OrderDisplayController> myOder;
          //  myOder = OrderDisplayController.
            
            return View();
        }
    }
}
