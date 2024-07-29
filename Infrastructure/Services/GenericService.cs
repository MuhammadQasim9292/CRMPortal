using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Common.CommonMethods;
using Common.Constants;
using Dapper;
using Domain.Models.Entities;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using static Dapper.SqlMapper;

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
        public  ValueTask<T> GetByIdAsync(long id)
        {
            return  _context.Set<T>().FindAsync(id);
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
        public async Task<bool> SoftDelete(long id,string tablename)
        {
            bool IsDeleted= await CommonOpertions.SoftDelete(CommonOpertions.GetConnectionString(), tablename, id);
            return IsDeleted;
        }
    }
}
