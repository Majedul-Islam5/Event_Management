using Microsoft.AspNetCore.Mvc;

namespace MVCAppLayer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
