using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class ReviewRepo
    {
        EventManagementContext db;

        public ReviewRepo(EventManagementContext db) { this.db = db; }
    }
}
