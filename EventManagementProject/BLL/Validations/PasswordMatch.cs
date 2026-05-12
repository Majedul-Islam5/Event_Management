using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Validations
{
    public class PasswordMatch : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance as RegistrationDTO;
            if (value != null && value.Equals(obj.Password))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Password and Cofirm Password does not match");
        }
    }
}
