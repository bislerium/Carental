﻿using Domain.Entities;

namespace Infrastructure.Persistence.Contexts
{
    public class AppDBContext: DbContext
    {

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        }
    }
}
