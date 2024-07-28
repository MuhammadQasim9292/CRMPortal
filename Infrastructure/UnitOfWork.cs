using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.Services.Repositories;

namespace Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly Database_context _context;
        public  RoleRepository _roleRepository;

        public UnitOfWork(Database_context context)
        {
            this._context = context;
        }
        public IRoleRepository Roles => _roleRepository = _roleRepository ?? new RoleRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
