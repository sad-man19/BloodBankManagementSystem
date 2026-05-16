using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class RequestRepo
    {
        BloodBankManagementSystemContext db; //db connection obj

        //constructor
        public RequestRepo(BloodBankManagementSystemContext db)
        {
            this.db = db;
        }
    }
}
