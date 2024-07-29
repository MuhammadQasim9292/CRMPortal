using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CommonMethods;
using Dapper;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Application.Interfaces
{
    public interface IGeneric<T> where T : class
    { 
        ValueTask<T> GetByIdAsync(long id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> SoftDelete(long id, string tablename);
}

}
