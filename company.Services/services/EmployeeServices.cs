using AutoMapper;
using comapny.Data.Models;
using company.Repo.Interfaces;
using company.Repo.repos;
using company.Services.Dto;
using company.Services.Helper;
using company.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace company.Services.services
{
    public class EmployeeServices : IEmployeeService
    {
        public readonly IunitWork IunitWork;
        private readonly IMapper mapper;

        public EmployeeServices(IunitWork _iunitWork,IMapper _mapper)
        {
            IunitWork = _iunitWork;
            mapper = _mapper;
        }

        public void add(EmployeeDto entity)
        {
            var emp = mapper.Map<Employee>(entity);
            IunitWork.employeeInterface.add(emp);
            IunitWork.complete();
        }

        public IEnumerable<EmployeeDto> getAll()
        {
            IEnumerable<Employee> employees = IunitWork.employeeInterface.getAll();
            var map = mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return map;
        }

        public EmployeeDto GetById(int id)
        {
            var emp = IunitWork.employeeInterface.GetById(id);
            var mappedEmp = mapper.Map<EmployeeDto>(emp);
            return mappedEmp;
        }

        public IEnumerable<EmployeeDto> getEmployeeByAddress(string address)
        {
            var emp = IunitWork.employeeInterface.getEmployeeByAddress(address);
            var mappedEmp = mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return mappedEmp;
        }

        public IEnumerable<EmployeeDto> getEmployeeByName(string name)
        {
            var emp = IunitWork.employeeInterface.getEmployeeByName(name);
            var mappedEmp = mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return mappedEmp;
        }

        public void remove(EmployeeDto entity)
        {
            var mappedEmp = mapper.Map<Employee>(entity);
            IunitWork.employeeInterface.remove(mappedEmp);
            IunitWork.complete();
        }

        public void update(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
