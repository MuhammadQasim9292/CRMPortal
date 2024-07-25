
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options)
            : base(options)
        {
        }

        public DbSet<DepartmentEntity> Departments { get; set; }
    }

    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeJobDescription> EmployeeJobDescriptions { get; set; }
    }
}
