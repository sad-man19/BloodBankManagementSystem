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
        //public bool CreateRequest(Request r)
        //{
        //    db.Requests.Add(r);
        //    return db.SaveChanges() > 0;
        //}

        public bool CreateRequest(Request r)
        {
            var data = new Request
            {
                UserId = r.UserId,
                BloodGroupId = r.BloodGroupId,
                Quantity = r.Quantity,
                ReqDate = r.ReqDate,
                Status = "Pending"
            };

            db.Requests.Add(data);
            return db.SaveChanges() > 0;
        }
        public List<Request> GetAll()
        {
            return db.Requests.ToList();
        }
        
        public bool DeleteRequest(int id)
        {
            var data = db.Requests.Find(id);
            db.Requests.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
