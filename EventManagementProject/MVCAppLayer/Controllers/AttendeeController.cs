using Microsoft.AspNetCore.Mvc;

namespace MVCAppLayer.Controllers
{
    public class AttendeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
