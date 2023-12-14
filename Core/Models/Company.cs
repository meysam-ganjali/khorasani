using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } 
        public string CompanuPhone { get; set; }
        public string CompanyAddress { get; set; }
        public string? CompanyLogo { get; set; }
    }
}