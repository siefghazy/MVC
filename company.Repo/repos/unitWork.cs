using comapny.Data.Contexts;
using company.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Repo.repos
{
    public class unitWork : IunitWork
    {
        private readonly CompanyDbContext context;

        public unitWork(CompanyDbContext _context)
        {
            departmentInterface = new DepartmentRepo(_context);
            employeeInterface = new EmployeeRepo(_context);
            context = _context;
        }

        public DepartmentInterface departmentInterface { get; set; }
        public EmployeeInterface employeeInterface { get; set; }

        public int complete() { return context.SaveChanges(); }
    }
}
