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

    }
}
