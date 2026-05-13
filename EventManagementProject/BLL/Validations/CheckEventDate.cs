using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Validations
{
    public class CheckEventDate : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            if (value is DateOnly date)
            {
                return date > DateOnly.FromDateTime(DateTime.Today);
            }

            return false;
        }
    }
}
