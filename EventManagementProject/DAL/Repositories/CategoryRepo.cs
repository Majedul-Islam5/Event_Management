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

        public Category GetCategoryByID(int id)
        {
            var data = (from u in db.Categories where u.CategoryId == id select u).FirstOrDefault();

            return data;
        }

        public bool DeleteCategory(int id)
        {
            var data = GetCategoryByID(id);
            db.Categories.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
