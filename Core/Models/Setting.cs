using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string Address { get; set; }
        public string? LogoPath { get; set; }
    }
}