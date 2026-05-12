using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Validations
{

    public class PasswordCorrect : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var service = (EventHubService)validationContext.GetService(typeof(EventHubService));
            var data = (LoginDTO)validationContext.ObjectInstance;

            if (value == null)
            {
                return null;
            }

            bool res = service.PasswordCheck(data.Email, value.ToString());
            if (res == true)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Wrong Password");
        }

    }
}
