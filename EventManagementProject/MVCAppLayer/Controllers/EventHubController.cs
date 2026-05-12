using BLL.DTOs;
using BLL.Services;
using DAL.EF.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCAppLayer.Controllers
{
    public class EventHubController : Controller
    {
        EventHubService service;

        public EventHubController(EventHubService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDTO() { });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginDTO dto)
        {
            if (ModelState.IsValid)
            {
                var data = service.CheckUser(dto);
                if (data != null)
                {
                    HttpContext.Session.SetString("UserName", data.Email);
                    HttpContext.Session.SetInt32("UserRole", data.FroleId);
                    switch (data.FroleId)
                    {
                        case 1: return RedirectToAction("AdminDashboard", "Admin");
                        case 2: return RedirectToAction("OrganizerDashboard", "Organizer");
                        case 3: return RedirectToAction("AttendeeDashboard", "Attendee");
                                            }
                }

            }
                return View(dto);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            ViewBag.Types = service.GetUserType();

            return View(new RegistrationDTO() { });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegistrationDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (service.Create(dto))
                {
                    TempData["Class"] = "alert-success";
                    TempData["Msg"] = "Registration Successfull";
                    ViewBag.Types = service.GetUserType();
                    return RedirectToAction("Registration");
                }

                TempData["Class"] = "alert-danger";
                TempData["Msg"] = "Registration failed";
                ViewBag.Types = service.GetUserType();
                return View(dto);
            }
            ViewBag.Types = service.GetUserType();
            return View(dto);
        }
    }
}
