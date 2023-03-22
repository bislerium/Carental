using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Infrastructure.Persistence.Contexts
{
    public class AppDBContext: DbContext
    {
        private readonly IHostingEnvironment? _environment;

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
        {
            //For migration purpose only
        }

        public AppDBContext(IHostingEnvironment environment)
        {
            _environment = environment;
        }

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            Console.WriteLine(configuration["ConnectionStrings"]);
            Debug.WriteLine(configuration["ConnectionStrings"]);

            optionsBuilder.UseSqlServer("Data Source=WALKAN\\SQLEXPRESS01;Database=Carental;Trusted_Connection=True;TrustServerCertificate=True");


            if (_environment?.IsDevelopment() ?? false)
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        }
    }
}
