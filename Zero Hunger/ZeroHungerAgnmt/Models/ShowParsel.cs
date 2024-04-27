using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerAgnmt.Models
{
    public class ShowParsel
    {
        public int Id { get; set; }
        public string RName { get; set; }
            public string FoodName { get; set; }
            public int PreservationTime { get; set; }
            public int TotalPacket { get; set; }
            public string Status { get; set; }
            //public int Employee { get; set; }
            // Add other properties as needed
        

    }
}