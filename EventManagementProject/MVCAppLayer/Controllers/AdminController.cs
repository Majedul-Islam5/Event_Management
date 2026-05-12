using Microsoft.AspNetCore.Mvc;
using MVCAppLayer.AuthFilter;

namespace MVCAppLayer.Controllers
{
    [Logged]
    [AdminAccess]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminDashboard() 
        {
            return View();
        }
    }
}
