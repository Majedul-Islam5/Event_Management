using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Booking
{
    public int BookingId { get; set; }

    public int FeventId { get; set; }

    public int AttendeeId { get; set; }

    public int NumberOfTickets { get; set; }

    public int TotalAmount { get; set; }

    public string BookingStatus { get; set; } = null!;

    public int PaymentStatus { get; set; }

    public virtual User Attendee { get; set; } = null!;

    public virtual Event Fevent { get; set; } = null!;
}
