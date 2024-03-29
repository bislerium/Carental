﻿using Carental.Domain.Entities;
using Carental.Infrastructure.Persistence.Repositories;

namespace Carental.Infrastructure.Persistence.Contexts
{
    public class AppDBContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarInventory> CarInventories { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
        public DbSet<CarDamage> CarDamages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DiscountOffer> DiscountOffers { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }

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
