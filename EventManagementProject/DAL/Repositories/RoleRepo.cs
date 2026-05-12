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
    }
}
