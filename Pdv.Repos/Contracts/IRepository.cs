using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdv.Interfaces
{
    public interface IRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetAll();

        T GetById(int Id);

        void Add(T entity);

        void Update(T entity);

        void Save();
    }
}
