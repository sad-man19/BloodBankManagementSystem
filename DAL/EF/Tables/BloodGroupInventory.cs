using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class BloodGroupInventory
{
    public int Id { get; set; }

    public string BloodGroup { get; set; } = null!;

    public int Inventory { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
