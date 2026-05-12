using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Event
{
    public int EventId { get; set; }

    public int OrganizerId { get; set; }

    public int FcategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Venue { get; set; } = null!;

    public DateOnly EventDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int TotalSeats { get; set; }

    public int AvailableSeats { get; set; }

    public int TicketPrice { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Category Fcategory { get; set; } = null!;

    public virtual User Organizer { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
