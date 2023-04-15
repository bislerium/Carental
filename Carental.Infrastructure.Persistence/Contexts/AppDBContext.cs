using Carental.Domain.Entities;

namespace Carental.Infrastructure.Persistence.Contexts
{
    public class AppDBContext: DbContext
    {

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {     
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        }
    }
}
