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
        public bool CreateDonation(Donation d)
        {
            db.Donations.Add(d);
            return db.SaveChanges() > 0;
        }
        public List<Donation> Get(int id)
        {
            return db.Donations
            .Where(x => x.UserId == id)
            .ToList();
        }
        public List<Donation> GetAll()
        {
            return db.Donations.ToList();
        }
    }
}
