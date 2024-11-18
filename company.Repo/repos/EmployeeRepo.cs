using comapny.Data.Contexts;
using comapny.Data.Models;
using company.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Repo.repos
{
    public class EmployeeRepo :EmployeeInterface
    {
        private readonly CompanyDbContext _context;
        public EmployeeRepo(CompanyDbContext context) 
        {
            _context = context;
        }

        public void add(Employee entity)
        {
           _context.Add(entity);
        }

        public IEnumerable<Employee> getAll()
        {
            return _context.employees.Include(x=>x.department).ToList();
        }

        public Employee GetById(int id)
        {
            return _context.employees.Include(x=>x.departmentId).FirstOrDefault(x=>x.ID==id);
        }

        public IEnumerable<Employee> getEmployeeByAddress(string address)
        {
            return _context.employees.Where(x=>x.address == address).Include(x=>x.department).ToList();
        }

        public IEnumerable<Employee> getEmployeeByName(string name)
        {
            return _context.employees.Where(x=>x.Name.Trim().ToLower().Contains(name.Trim().ToLower())).Include(x=>x.department).ToList();
        }

        public void remove(Employee entity)
        {
            _context.Remove(entity);
        }

        public void update(Employee entity)
        {
            var emp = GetById(entity.ID);
            emp.email = entity.email;
            emp.address = entity.address;
            emp.phoneNumber = entity.phoneNumber;
            emp.hiringDate = entity.hiringDate;
            emp.Age = entity.Age;
            emp.departmentId = entity.departmentId;
            _context.employees.Update(emp);
        }
    }
}
