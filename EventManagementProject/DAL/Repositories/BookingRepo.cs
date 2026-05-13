using DAL.EF;
using DAL.EF.Tables;
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
            tempData.AvailableSeats= tempData.AvailableSeats-data.NumberOfTickets;
            return db.SaveChanges() > 0;
        }
    }
}
