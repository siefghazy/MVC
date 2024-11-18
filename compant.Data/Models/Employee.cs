using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comapny.Data.Models
{
    public class Employee: BaseEntity
    {
        public  string? Name { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        public double? salary { get; set; }
        public string? email { get; set; }
        public int? Age { get; set; }
        public string? ImageURl { get; set; }
        public DateTime? hiringDate { get; set; }
        public Department department { get; set; }
        public int? departmentId { get; set; }
    }
}
