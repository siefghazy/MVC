using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comapny.Data.Models
{
    public class Department:BaseEntity
    {
        public string? Name { get; set; }
        public string? codde { get; set; }
        public ICollection<Employee> employees { get; set; }
    }
}
