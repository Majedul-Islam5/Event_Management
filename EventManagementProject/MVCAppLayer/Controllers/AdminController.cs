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
        public IActionResult CreateCategory()
        {
            return View(new CategoryTypeDTO() { });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(CategoryTypeDTO dto)
        {

            if (ModelState.IsValid)
            {
                service.CreateCategory(dto);
                return RedirectToAction("ShowCategory");
            }
            return View(dto);
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


        [HttpGet]
        public IActionResult ShowCategory()
        {
            var data = service.ShowCategory();
            return View(data);
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var data = service.GetCategoryByID(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id, string Decision)
        {
            if (Decision.Equals("Yes"))
            {
                service.DeleteCategory(id);
            }

            return RedirectToAction("AdminDashboard");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var data = service.GetCategoryByID(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory(CategoryTypeDTO dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateCategory(dto);
                return RedirectToAction("AdminDashboard");
            }
            return View(dto);
        }




        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string to, string subject, string body)
        {
            service.SendEmail(to, subject, body);
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "EventHub");
        }


    }
}
