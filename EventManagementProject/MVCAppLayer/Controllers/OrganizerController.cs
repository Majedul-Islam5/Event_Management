using Microsoft.AspNetCore.Mvc;
using MVCAppLayer.AuthFilter;

namespace MVCAppLayer.Controllers
{
    [Logged]
    [OrganizerAccess]
    public class OrganizerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrganizerDashboard()
        {
            return View();
        }
    }
}
