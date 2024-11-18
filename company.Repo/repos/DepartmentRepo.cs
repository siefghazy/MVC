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
    public class DepartmentRepo: GenericRepo<Department>,DepartmentInterface
    {
        private readonly CompanyDbContext _context;

        public DepartmentRepo(CompanyDbContext context):base(context)
        {
            _context = context;
        }
    }
}
