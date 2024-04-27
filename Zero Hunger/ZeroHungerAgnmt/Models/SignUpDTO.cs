using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerAgnmt.Models
{
    public class SignUpDTO
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Enter your Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Your Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Restaurant Name")]
        [StringLength(50, ErrorMessage = "Name can not Exceed 50 Characters")]
        public string RName { get; set; }

        [Required(ErrorMessage = "Enter Restuarant Address")]
        public string Address { get; set; }

        public int AccountType { get; set; }
    }
}