using comapny.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Repo.Interfaces
{
    public interface GenericInterface<T> 
    {
        T GetById(int id);
        void add(T entity);
        void remove(T entity);
        void update(T entity);
        IEnumerable<T> getAll();

    }
}
