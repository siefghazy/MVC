using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Repo.Interfaces
{
    public interface IunitWork
    {
        public DepartmentInterface departmentInterface { get; set; }
        public EmployeeInterface employeeInterface { get; set; }
        int complete();
    }
}
