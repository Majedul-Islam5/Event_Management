using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using MVCAppLayer.AuthFilter;
using System;

namespace MVCAppLayer.Controllers
{
    [Logged]
    [AdminAccess]
    public class AdminController : Controller
    {
        AdminService service;

        public AdminController(AdminService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            var data = service.GetAllEvents();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminDashboard(EventDTO dto, string Decision)
        {
            dto = service.GetEventByID(dto.EventId);
            dto.Organizer = service.GetUserByID(dto.OrganizerId);
            dto.Status = Decision;
            service.UpdateEvent(dto);
            return RedirectToAction("AdminDashboard");
        }


        [HttpGet]
        public IActionResult ShowUser()
        {
            var data = service.GetAllUsers();
            return View(data);
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var data = service.GetUserByID(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult DeleteUser(int id, string Decision)
        {
            if (Decision.Equals("Yes"))
            {
                service.DeleteUser(id);
            }

            return RedirectToAction("AdminDashboard");
        }


    }
}
