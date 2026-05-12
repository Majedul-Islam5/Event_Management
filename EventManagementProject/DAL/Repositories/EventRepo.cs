using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class EventRepo
    {
        EventManagementContext db;

        public EventRepo(EventManagementContext db) { this.db = db; }
    }
}
