using Domain.Repositories;
using Domain.UnitOfWork;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    public static class Startup
    {
        public static void AddInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DomainDB"));
            });

            services.AddScoped<IRepositories, AppRepositories>();
            services.AddScoped<IUnitOfWork, AppUnitOfWork>();
        }
    }
}
