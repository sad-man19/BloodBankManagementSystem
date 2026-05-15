using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Request
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BloodGroupId { get; set; }

    public int Quantity { get; set; }

    public DateOnly ReqDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual BloodGroupInventory BloodGroup { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
