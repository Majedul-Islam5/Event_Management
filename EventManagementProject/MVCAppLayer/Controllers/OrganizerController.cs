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

        [HttpGet]
        public IActionResult OrganizerDashboard()
        {
            int id = service.GetID(HttpContext.Session.GetString("UserName"));
            var data = service.GetOrganizerEvents(id);
            return View(data);
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

        [HttpGet]
        public IActionResult DeleteEvent(int id)
        {
            var data = service.GetEventByID(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult DeleteEvent(int id, string Decision)
        {
            if (Decision.Equals("Yes"))
            {
                service.DeleteEvent(id);
            }

            return RedirectToAction("OrganizerDashboard");

        }

        [HttpGet]
        public IActionResult UpdateEvent(int id)
        {
            var data = service.GetEventByID(id);
            ViewBag.Types = service.GetCategoryType();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateEvent(EventDTO dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateEvent(dto);
                return RedirectToAction("OrganizerDashboard");
            }
            ViewBag.Types = service.GetCategoryType();
            return View(dto);
        }



    }
}
