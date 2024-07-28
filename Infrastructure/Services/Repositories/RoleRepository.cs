using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Entities;
using Infrastructure.Context;

namespace Infrastructure.Services.Repositories
{
  public class RoleRepository:GenericRepository<Role>,IRoleRepository
    {
        public RoleRepository(Database_context context)
             : base(context)
        { }

        private Database_context Database_context
        {
            get { return _context as Database_context; }
        }
    }
   
}
