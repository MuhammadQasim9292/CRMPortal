using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context
{
    public  class Database_context:DbContext
    {
        public Database_context(DbContextOptions<Database_context> options):base(options)
        {
            
        }
        public DbSet<Types> TypeNew { get; set; }
        public DbSet<TypeValue> TypeValueNew { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
