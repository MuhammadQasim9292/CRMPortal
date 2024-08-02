
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{

    public class Database_Context : DbContext
    {
        public Database_Context(DbContextOptions<Database_Context> options)
            : base(options)
        {
        }

        public DbSet<EmployeeJobDescription> EmployeeJobDescriptions { get; set; }
        public DbSet<Types> TypeNew { get; set; }
        public DbSet<TypeValue> TypeValueNew { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
