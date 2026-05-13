using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using MVCAppLayer.AuthFilter;

namespace MVCAppLayer.Controllers
{
    [Logged]
    [AttendeeAccess]
    public class AttendeeController : Controller
    {
        AttendeeService service;

        public AttendeeController(AttendeeService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AttendeeDashboard(string Title, int CategoryId)
        {
            ViewBag.Types = service.GetCategoryType();

            var data = service.GetEvents(Title, CategoryId);
            return View(data);
        }

        [HttpGet]

        public IActionResult BuyTicket(int id)
        {
            var data = service.GetEventByID(id);
            return View(data);
        }

        [HttpPost]

        public IActionResult BuyTicket(BookingDTO dto, int TicketPrice)
        {
            int id = service.GetID(HttpContext.Session.GetString("UserName"));
            dto.AttendeeId = id;
            dto.TotalAmount = TicketPrice * dto.NumberOfTickets;

            if (service.CreateTicket(dto))
            {
                return RedirectToAction("AttendeeDashboard");
            }


            return View(dto);
        }

        [HttpGet]
        public IActionResult Review()
        {
            return View();
        }



    }
}
