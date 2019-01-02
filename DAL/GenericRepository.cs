using Gaditas.Entities;
using GaditasDataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.DAL
{
    public class GenericRepository<T> where T : class
    {
        private AppDataContext _context;

        public GenericRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }
        public async Task<T> FindByIDAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public T FindByID(object id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
             _context.Entry(entity).State = EntityState.Modified;
        }
        public T Delete(T entity)
        {
            if (entity != null)
                _context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
