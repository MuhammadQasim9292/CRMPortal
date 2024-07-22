using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities;

namespace Infrastructure.Context
{
    public  class Database_context:DbContext
    {
        public Database_context(DbContextOptions<Database_context> options):base(options)
        {
            
        }

      public  DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Database_context).Assembly);
        }
    }
}
