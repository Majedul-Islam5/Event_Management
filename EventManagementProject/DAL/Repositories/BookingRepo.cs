using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class BookingRepo
    {
        EventManagementContext db;

        public BookingRepo(EventManagementContext db) { this.db = db; }
    }
}
