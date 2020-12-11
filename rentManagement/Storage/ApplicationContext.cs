using Microsoft.EntityFrameworkCore;
using rentManagement.Storage.EFModels;

namespace rentManagement.Storage
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Assignment> Assignments { get; set; } 
    }
}