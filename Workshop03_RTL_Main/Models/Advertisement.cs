using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop03_RTL_Main.Models
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public int NumberOfSubscribers{ get; set; }
    }
}
