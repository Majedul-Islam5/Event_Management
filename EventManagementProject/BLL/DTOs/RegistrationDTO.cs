using BLL.Validations;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class RegistrationDTO
    {
        public int UserId { get; set; }


        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [EmailUnique]
        public string Email { get; set; }

        [Required]
        [StringLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,8}$", ErrorMessage = "Password must contain at least 1 uppercase, 1 lowercase, and 1 number (6-8 characters).")]
        public string Password { get; set; }

        [Required]
        [StringLength(8)]
        [PasswordMatch]
        public string ConfPassword { get; set; }

        [Required]
        public int IsActive { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Please select a valid role.")]
        public int FroleId { get; set; }

        public  RoleTypeDTO? Frole { get; set; }
    }
}
