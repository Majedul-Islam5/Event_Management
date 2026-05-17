using DAL.EF;
using DAL.EF.Tables;
using Microsoft.Extensions.Options;
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

        public bool CreateCategory(Category data)
        {
            db.Categories.Add(data);
            return db.SaveChanges() > 0;
        }

        public List<Category> ShowCategory()
        {
            return db.Categories.ToList();
        }

        public bool UpdateCategory(Category data)
        {
            var exobj = GetCategoryByID(data.CategoryId);
            db.Entry(exobj).CurrentValues.SetValues(data);

            return db.SaveChanges()>0;
        }

        public bool DeleteCategory(int id)
        {
            var data = GetCategoryByID(id);
            db.Categories.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
