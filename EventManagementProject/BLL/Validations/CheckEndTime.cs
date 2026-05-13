using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Validations
{
    public class CheckEndTime : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var data = validationContext.ObjectInstance as EventDTO;

            if (value == null || data.StartTime == null)
            {
                return null;
            }

            TimeOnly endTime = (TimeOnly)value;

            if (endTime > data.StartTime)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("End Time can not be greater than start time");
        }

    }
}
