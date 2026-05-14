using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class ReviewRepo
    {
        EventManagementContext db;

        public ReviewRepo(EventManagementContext db) { this.db = db; }

        public bool CreateReview(Review data)
        {
            db.Reviews.Add(data);
            return db.SaveChanges()>0;
        }
    }
}
