using AutoMapper;
using comapny.Data.Models;
using company.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Services.profile
{
    public class departmentProfile : Profile
    {
        public departmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
