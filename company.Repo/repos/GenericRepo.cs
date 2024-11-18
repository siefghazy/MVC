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
    public class GenericRepo<T> : GenericInterface<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;
        public GenericRepo(CompanyDbContext context )
        {
            _context = context;
        }

        public void add(T entity)
        {
            _context.Add(entity);
        }

        public IEnumerable<T> getAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void remove(T entity)
        {
            _context.Remove(entity);
        }

        public  void update(T entity)
        {
            
            _context.Update(entity);
        }
    }
}
