using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class EventRepo
    {
        EventManagementContext db;

        public EventRepo(EventManagementContext db) { this.db = db; }

        public bool Create(Event data)
        {
            db.Events.Add(data);
            return db.SaveChanges() > 0;
        }

        public List<Event> GetOrganizerEvents(int id)
        {
            var data = (from u in db.Events where u.OrganizerId == id select u).ToList();

            return data;
        }

        public List<Event> GetEvents(string Title, int CategoryId)
        {
            var data = (from u in db.Events where u.Status == "Approved" && u.AvailableSeats > 0 select u).ToList();

            if (Title != null)
            {
                data = (from u in db.Events where u.Status == "Approved" && u.AvailableSeats > 0 && u.Title.Contains(Title) select u).ToList();
            }

            if (CategoryId > 0)
            {
                data = (from u in db.Events where u.Status == "Approved" && u.AvailableSeats > 0 && u.FcategoryId == CategoryId select u).ToList();
            }

            if (CategoryId > 0 && Title != null)
            {
                data = (from u in db.Events where u.Status == "Approved" && u.AvailableSeats > 0 && u.FcategoryId == CategoryId && u.Title.Contains(Title) select u).ToList();
                if (data == null)
                {
                    data = (from u in db.Events where u.Status == "Approved" && u.AvailableSeats > 0 select u).ToList();
                }
            }

            return data;
        }

        public Event GetEventByID(int id)
        {
            var data = (from u in db.Events where u.EventId == id select u).FirstOrDefault();

            return data;
        }

        public bool DeleteEvent(int id)
        {
            var review = (from u in db.Reviews where u.ReventId == id select u).ToList();

            if (review != null)
            {
                db.Reviews.RemoveRange(review);
            }

            var booking = (from u in db.Bookings where u.FeventId == id select u).ToList();

            if (booking != null)
            {
                db.Bookings.RemoveRange(booking);
            }

            var data = GetEventByID(id);
            db.Events.Remove(data);

            return db.SaveChanges()>0;
        }
    }
}
