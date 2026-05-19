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
        public List<BloodGroupInventory> Get()
        {
            return db.BloodGroupInventories.ToList();
        }
        public BloodGroupInventory Get(int id)
        {
            return db.BloodGroupInventories.Find(id);
        }
        public bool UpdateStock(int bloodGroupId)
        {
            var qty = db.BloodGroupInventories.Find(bloodGroupId);
            qty.Inventory += 1;
            return db.SaveChanges() > 0;
        }
    }
}
