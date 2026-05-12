using Microsoft.AspNetCore.Mvc;

namespace MVCAppLayer.Controllers
{
    public class OrganizerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
