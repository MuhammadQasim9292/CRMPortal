using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class GenericService<T> : IGeneric<T> where T : class
    {
        protected readonly Database_context _context;
        public GenericService(Database_context context)
        {
            _context = context;

        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            return _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T id)
        {
            // var entity = await _context.FindAsync(id);
            //if (entity != null)
            //{
            //  _context.Remove(entity);
            await _context.SaveChangesAsync();
            //}
        }
    }
}
