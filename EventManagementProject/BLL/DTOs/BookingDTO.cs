using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }

        public int FeventId { get; set; }

        public int AttendeeId { get; set; }

        public int NumberOfTickets { get; set; }

        public int TotalAmount { get; set; }

        public string BookingStatus { get; set; } 

        public int PaymentStatus { get; set; }
    }
}
