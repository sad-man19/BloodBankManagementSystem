using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class DonationRepo
    {
        BloodBankManagementSystemContext db; //db connection obj

        //constructor
        public DonationRepo(BloodBankManagementSystemContext db)
        {
            this.db = db;
        }
    }
}
