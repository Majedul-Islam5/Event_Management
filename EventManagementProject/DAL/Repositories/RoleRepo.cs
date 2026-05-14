using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class RoleRepo
    {
        EventManagementContext db;

        public RoleRepo(EventManagementContext db) { this.db = db; }

        public List<Role> GetUserTypes()
        {
            return db.Roles.ToList();
        }

        public Role GetRoleByID(int id)
        {
            var data = (from u in db.Roles where u.RoleId == id select u).FirstOrDefault();

            return data;
        }

        public bool DeleteRole(int id)
        {
            var data = GetRoleByID(id);
            db.Roles.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
