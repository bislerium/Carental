using Domain.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    public static class Startup
    {
        public static void AddInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDB"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
