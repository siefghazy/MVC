using comapny.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Repo.Interfaces
{
    public interface EmployeeInterface:GenericInterface<Employee>
    {
        public IEnumerable<Employee> getEmployeeByName(string name);
        public IEnumerable<Employee> getEmployeeByAddress(string address);
    }
}
