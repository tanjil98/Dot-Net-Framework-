using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerAgnmt.Models
{
    public class ParselDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Your Food Name")]
        public string FoodName { get; set; }
        [Required(ErrorMessage = "Enter Your Preservation Time")]
        public int PreservationTime { get; set; }
        [Required(ErrorMessage = "Total Packet number")]
        public int TotalPacket { get; set; }
        public Nullable<int> Employee { get; set; }
        public string Status { get; set; }
        public int RId { get; set; }
    }
}