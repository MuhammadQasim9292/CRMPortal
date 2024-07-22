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
        public DbSet<Types>Types{ get; set; }
        public DbSet<TypeValue>TypeValue { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Database_context).Assembly);
        }
    }
}
