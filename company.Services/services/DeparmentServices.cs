using AutoMapper;
using comapny.Data.Models;
using company.Repo.Interfaces;
using company.Repo.repos;
using company.Service.interfaces;
using company.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Service.services
{
    public class DeparmentServices : IDepartmentService
    {
        private readonly IunitWork unitwork;
        private readonly IMapper mapper;

        public DeparmentServices(IunitWork _unitWork,IMapper _mapper)
        {
            unitwork = _unitWork;
            mapper= _mapper;
        }

        public void add(DepartmentDto entity)
        {
             var mappedEntity=mapper.Map<Department>(entity);
            unitwork.departmentInterface.add(mappedEntity);
            unitwork.complete();
        }

        public IEnumerable<DepartmentDto> getAll()
        {
            var emp = unitwork.departmentInterface.getAll();
            IEnumerable<DepartmentDto> mappedDept = mapper.Map<IEnumerable<DepartmentDto>>(emp);
            return mappedDept;
        }

        public DepartmentDto GetById(int id)
        {
            var emp = unitwork.departmentInterface.GetById(id);
            var mappedEmp = mapper.Map<DepartmentDto>(emp);
            return mappedEmp;
        }

        public void remove(DepartmentDto entity)
        {
            var mappedEmp = mapper.Map<Department>(entity);
            unitwork.departmentInterface.remove(mappedEmp);
            unitwork.complete();
        }

        public void update(DepartmentDto entity)
        {
            
        }
    }
}
