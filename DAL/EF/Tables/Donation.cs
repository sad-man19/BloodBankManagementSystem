using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Donation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateOnly DonationDate { get; set; }

    public int BloodGroupId { get; set; }

    public virtual BloodGroupInventory BloodGroup { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
