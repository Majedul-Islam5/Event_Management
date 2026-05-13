using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using MVCAppLayer.AuthFilter;

namespace MVCAppLayer.Controllers
{
    [Logged]
    [OrganizerAccess]
    public class OrganizerController : Controller
    {
        OrganizerService service;

        public OrganizerController(OrganizerService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrganizerDashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            ViewBag.Types = service.GetCategoryType();

            return View(new EventDTO() { });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(EventDTO dto) 
        {
            int id = service.GetID(HttpContext.Session.GetString("UserName"));
            dto.OrganizerId = id;

            if (ModelState.IsValid)
            {
                service.Create(dto);
                TempData["Class"] = "alert-success";
                TempData["Msg"] = "Event Created Waiting for Approval";
                return RedirectToAction("OrganizerDashboard");
            }
            ViewBag.Types = service.GetCategoryType();
            return View(dto);
        }
    }
}
