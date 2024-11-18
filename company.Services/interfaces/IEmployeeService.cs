using comapny.Data.Models;
using company.Repo.Interfaces;
using company.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Services.interfaces
{
    public interface IEmployeeService: GenericInterface<EmployeeDto>
    {
        public IEnumerable<EmployeeDto> getEmployeeByName(string name);
        public IEnumerable<EmployeeDto> getEmployeeByAddress(string address);

    }
}
