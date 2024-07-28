﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

       Task<IEnumerable<T>> GetAllAsync();



        ValueTask<T> GetByIdAsync(int id);


       Task AddAsync(T entity);


      Task UpdateAsync(T entity);

       Task DeleteAsync(T id);
     

    }
}
