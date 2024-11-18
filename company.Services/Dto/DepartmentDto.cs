using comapny.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Services.Dto
{
    public class DepartmentDto:BaseEntity
    {
        public string? Name { get; set; }
        public string? codde { get; set; }
        public ICollection<EmployeeDto> employees { get; set; }
    }
}
