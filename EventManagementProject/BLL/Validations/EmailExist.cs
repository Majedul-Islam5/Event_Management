using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Validations
{
    public class EmailExist : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var service = (EventHubService)validationContext.GetService(typeof(EventHubService));

            if (value == null)
            {
                return null;
            }

            bool res = service.EmailExists(value.ToString());
            if (res == true)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("User with this email does not exist");
        }

    }
}
