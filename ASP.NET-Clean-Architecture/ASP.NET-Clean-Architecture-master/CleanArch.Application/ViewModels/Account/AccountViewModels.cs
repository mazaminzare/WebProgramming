using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    public enum CheckUser
    {
        EmailNotValid,
        UserNameNotValid,
        Ok,
        UserNameAndEmailNotValid
    }
}
