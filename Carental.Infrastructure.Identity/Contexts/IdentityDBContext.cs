using Carental.Domain.Entities;
using Carental.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Carental.Infrastructure.Identity.Contexts
{
    internal class IdentityDBContext: IdentityDbContext<AppUser>
    {
        public IdentityDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDBContext).Assembly);
        }
    }
}
