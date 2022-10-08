using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Workshop03_RTL_Main.Models
{
    public class Subscribers
    {
        [Key]
        public string Id { get; set; }
        public string AdId { get; set; }
        public string SubId { get; set; }

        public Subscribers()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
