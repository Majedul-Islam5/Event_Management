using BLL.DTOs;
using BLL.Services;
using DAL.EF.Tables;
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
            return View();
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
