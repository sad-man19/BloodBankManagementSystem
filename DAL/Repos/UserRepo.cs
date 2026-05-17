using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
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
    }
}
