using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int BloodGroupId { get; set; }

    public string Role { get; set; } = null!;

    public DateOnly? LastDonationDate { get; set; }

    public DateOnly Dob { get; set; }

    public virtual BloodGroupInventory BloodGroup { get; set; } = null!;

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
