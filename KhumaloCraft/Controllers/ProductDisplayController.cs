using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
    public class ProductDisplayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
