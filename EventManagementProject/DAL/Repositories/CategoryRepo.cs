using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CategoryRepo
    {
        EventManagementContext db;

        public CategoryRepo(EventManagementContext db) { this.db = db; }
    }
}
