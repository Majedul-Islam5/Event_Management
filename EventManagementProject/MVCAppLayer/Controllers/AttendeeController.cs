using Microsoft.AspNetCore.Mvc;
using MVCAppLayer.AuthFilter;

namespace MVCAppLayer.Controllers
{
    [Logged]
    [AttendeeAccess]
    public class AttendeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AttendeeDashboard()
        {
            return View();
        }
    }
}
