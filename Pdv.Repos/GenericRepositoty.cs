using pdv.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace pdv.Services
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _DbContext;
        private DbSet<T> _DbSet;


        public GenericRepository(DbContext context)
        {
            this._DbContext = context;
            this._DbSet = this._DbContext.Set<T>();
        }
        public async Task <IEnumerable<T>> GetAll()
        {
            return await this._DbSet.ToListAsync();
        }

        public T GetById(int Id)
        {
          return this._DbSet.Find(Id);
        }

        public void Add(T entity)
        {
            this._DbSet.Add(entity);
        }

        public void AddRange(List<T> entity)
        {
            this._DbSet.AddRange(entity);
        }

        public void Update(T entity)
        {
            this._DbSet.Attach(entity);
            this._DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this._DbSet.Remove(entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
