using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHungerAgnmt.Database;

namespace ZeroHungerAgnmt.Models
{
    public class parselempDTO
    {
        public List<ShowParsel> Parsels { get; set; }
        public List<Emplyo> Employees { get; set; }
        // Other properties as needed
    }

}