using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class TemplatesContext : DbContext
    {
        public TemplatesContext(DbContextOptions<TemplatesContext> options)
            : base(options)
        {
        }

        public DbSet<Template> Templates { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure LeaveBalance entity
            modelBuilder.Entity<LeaveBalance>(entity =>
            {
                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18, 2)"); // Precision 18, Scale 2

                entity.Property(e => e.Availed)
                    .HasColumnType("decimal(18, 2)"); // Precision 18, Scale 2

                entity.Property(e => e.UpdatedBy)
                    .IsRequired(); // Ensure UpdatedBy cannot be NULL
            });

            // Additional model configurations can go here

            base.OnModelCreating(modelBuilder);
        }
    }
}
