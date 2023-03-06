using Domain.Entities;
using Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class AppDBContext: IdentityDbContext<AppUser>
    {
        private readonly IHostingEnvironment? _environment;

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public AppDBContext()
        {
            //For migration purpose only
        }

        public AppDBContext(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=WALKAN\\SQLEXPRESS01;Database=Carental;Trusted_Connection=True;TrustServerCertificate=True");
            if (_environment?.IsDevelopment() ?? false) { 
               optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        }
    }
}
