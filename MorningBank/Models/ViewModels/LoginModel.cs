using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MorningBank.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
    }
}