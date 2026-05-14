using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class BookingRepo
    {
        EventManagementContext db;

        public BookingRepo(EventManagementContext db) { this.db = db; }

        public bool Create(Booking data)
        {
            db.Bookings.Add(data);
            var tempData = db.Events.Find(data.FeventId);
            tempData.AvailableSeats = tempData.AvailableSeats - data.NumberOfTickets;
            return db.SaveChanges() > 0;
        }

        public List<Booking> ConfBooking(int id)
        {
            var data = (from u in db.Bookings.Include(x => x.Fevent) where u.BookingStatus == "Confirmed" && u.PaymentStatus == 1 && u.AttendeeId==id && !db.Reviews.Any(r => r.ReventId == u.FeventId
                                 && r.RattendeeId == id)
                        select u).ToList();

            return data;
        }
    }
}
