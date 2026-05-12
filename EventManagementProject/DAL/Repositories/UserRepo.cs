using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepo
    {
        EventManagementContext db;

        public UserRepo(EventManagementContext db) { this.db = db; }

        public bool EmailExists(string email)
        {
            var user = (from u in db.Users where u.Email == email select u).SingleOrDefault();
            if (user == null)
            {
                return false;
            }

            return true;
        }

        public bool PasswordCheck(string Email, string Password)
        {
            var user = (from u in db.Users where u.Email == Email && u.Password == Password select u).SingleOrDefault();
            if (user == null)
            {
                return false;
            }

            return true;
        }

        public User CheckUser(User user)
        {
            var userData = (from u in db.Users where u.Email == user.Email && u.Password == user.Password select u).SingleOrDefault();
            if (userData != null)
            {
                return userData;
            }

            return null;
        }

        public bool Create(User user)
        {
            db.Users.Add(user);
            return db.SaveChanges() > 0;
        }

        
    }
}
