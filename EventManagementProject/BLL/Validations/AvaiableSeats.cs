using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Validations
{
    public class AvaiableSeats : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var data = validationContext.ObjectInstance as EventDTO;

            if (value==null|| data.TotalSeats == null)
            {
                return null;
            }

            int availableSeats = (int)value;

            if (availableSeats<=data.TotalSeats)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Available seats cannot exceed total seats");
        }

    }
}
