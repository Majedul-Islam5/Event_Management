using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var data = (from u in db.Bookings.Include(x => x.Fevent)
                        where u.BookingStatus == "Confirmed" && u.PaymentStatus == 1 && u.AttendeeId == id && !db.Reviews.Any(r => r.ReventId == u.FeventId
                                 && r.RattendeeId == id)
                        select u).ToList();

            return data;
        }

        public List<Booking> ShowBooking(int id)
        {
            var data = (from u in db.Bookings.Include(x => x.Fevent)
                        where u.BookingStatus == "Booked" && u.PaymentStatus == 0 && u.AttendeeId == id && !db.Reviews.Any(r => r.ReventId == u.FeventId
                                 && r.RattendeeId == id)
                        select u).ToList();

            return data;
        }

        public Booking GetBookingById(int id)
        {
            var data = (from u in db.Bookings.Include(x => x.Fevent) where u.BookingId == id select u).FirstOrDefault();

            return data;
        }

        public bool UpdateBooking(Booking data)
        {
            var exobj = GetBookingById(data.BookingId);
            db.Entry(exobj).CurrentValues.SetValues(data);

            return db.SaveChanges() > 0;
        }

        public bool CancelBooking(int id)
        {
            var exobj = GetBookingById(id);
            exobj.Fevent.AvailableSeats += exobj.NumberOfTickets;
            db.Bookings.Remove(exobj);

            return db.SaveChanges()>0;
        }
    }
}
