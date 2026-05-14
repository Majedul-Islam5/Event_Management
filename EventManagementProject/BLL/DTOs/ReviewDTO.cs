using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }

        public int ReventId { get; set; }

        public int RattendeeId { get; set; }

        [Range(1, 5, ErrorMessage = "Please select a rating to rate the event")]
        public int Rating { get; set; }

        [Required(ErrorMessage ="Please write a review")]
        public string Comment { get; set; } 
    }
}
