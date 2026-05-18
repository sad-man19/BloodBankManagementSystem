using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Repos
{
    public class UserRepo
    {
        BloodBankManagementSystemContext db; //db connection obj

        //constructor
        public UserRepo(BloodBankManagementSystemContext db)
        {
            this.db = db;
        }
        public bool EmailExists(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }
        public bool PhoneExists(string phone)
        {
            return db.Users.Any(u => u.Phone == phone);
        }
        public bool Create(User u)
        {
            db.Users.Add(u);
            return db.SaveChanges() > 0;
        }
        public User Login(string email, string password)
        {
            //return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return (from u in db.Users
            where u.Email == email && u.Password == password
            select u).SingleOrDefault();
        }
        //public User Get(int id)
        //{
        //    var user =  db.Users.Find(id);
        //    if (user != null)
        //    {
        //        user.BloodGroupInventory = db.BloodGroupInventories.Find(user.BloodGroupId);
        //    }
        //    return user;
        //}
        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public BloodGroupInventory GetBloodGroup(int id)
        {
            return db.BloodGroupInventories.Find(id);
        }

        public bool Update(User u)
        {
            var exUser = db.Users.Find(u.Id);
            if (exUser == null)
            {
                return false;
            }
            exUser.Email = u.Email;
            exUser.Phone = u.Phone;
            return db.SaveChanges() > 0;
        }
    }
}
