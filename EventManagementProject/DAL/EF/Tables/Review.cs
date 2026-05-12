using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Review
{
    public int ReviewId { get; set; }

    public int ReventId { get; set; }

    public int RattendeeId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = null!;

    public virtual User Rattendee { get; set; } = null!;

    public virtual Event Revent { get; set; } = null!;
}
