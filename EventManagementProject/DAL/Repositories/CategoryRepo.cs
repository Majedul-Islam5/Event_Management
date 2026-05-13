using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CategoryRepo
    {
        EventManagementContext db;

        public CategoryRepo(EventManagementContext db) { this.db = db; }

        public List<Category> GetCategoryType()
        {
            return db.Categories.ToList();
        }
    }
}
