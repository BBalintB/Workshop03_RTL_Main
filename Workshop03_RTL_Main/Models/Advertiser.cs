using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop03_RTL_Main.Models
{
    public class Advertiser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int MinimumWage { get; set; }
    }
}
