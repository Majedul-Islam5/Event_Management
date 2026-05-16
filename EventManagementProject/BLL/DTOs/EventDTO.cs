using BLL.Validations;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class EventDTO
    {
        public int EventId { get; set; }
        public int OrganizerId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Category")]
        public int FcategoryId { get; set; }


        [Required]
        public string Title { get; set; }


        [Required]
        public string Description { get; set; }


        [Required]
        public string Venue { get; set; }


        [Required(ErrorMessage = "Please select an event date")]
        [CheckEventDate(ErrorMessage = "Date must be in future")]
        public DateOnly? EventDate { get; set; }


        [Required(ErrorMessage = "Please select a start time")]
        public TimeOnly? StartTime { get; set; }


        [Required(ErrorMessage = "Please select an end time")]
        [CheckEndTime(ErrorMessage = "Invalid End time")]
        public TimeOnly? EndTime { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Please select Total Seats")]
        public int TotalSeats { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Please select valid AvailableSeats")]
        [AvaiableSeats]
        public int AvailableSeats { get; set; }


        [Range(100, int.MaxValue, ErrorMessage = "Please select a valid ticket price")]
        public int TicketPrice { get; set; }


        [Required]
        public string Status { get; set; }

        public RegistrationDTO Organizer { get; set; }
    }
}
