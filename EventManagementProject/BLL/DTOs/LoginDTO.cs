using BLL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        [EmailExist]
        public string Email { get; set; }


        [Required]
        [PasswordCorrect]
        public string Password { get; set; }

        public int FroleId { get; set; }
    }
}
