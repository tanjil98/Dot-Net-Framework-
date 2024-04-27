using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerAgnmt.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Enter Your Email")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Enter a valid email address")]
        public string username { get; set; }
        [Required(ErrorMessage = "Enter Your Password")]
        public string password { get; set; }
    }
}