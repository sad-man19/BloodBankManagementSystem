using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class BloodGroupInventoryRepo
    {
        BloodBankManagementSystemContext db; //db connection obj

        //constructor
        public BloodGroupInventoryRepo(BloodBankManagementSystemContext db)
        {
            this.db = db;
        }
    }
}
