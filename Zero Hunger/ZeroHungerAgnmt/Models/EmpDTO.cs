using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerAgnmt.Models
{
    public class EmpDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Emp Name")]
        [StringLength(50, ErrorMessage = "Name can not Exceed 50 Characters")]
        [RegularExpression(@"^[A-Za-z\s.]+$", ErrorMessage = "Name Only Content Letter, Space and Dot")]
        public string EName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

       
        [Required(ErrorMessage = "Enter Passowrd")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address{ get; set; }

        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; }

        public int AccountType { get; set; }
    }
}