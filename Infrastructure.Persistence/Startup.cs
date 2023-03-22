using Domain.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    public static class Startup
    {
        public static void AddInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment hostingEnvironment) {
            services.AddDbContext<AppDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("Application"));

                if (hostingEnvironment.IsDevelopment()) {
                    options.EnableSensitiveDataLogging();
                }
            });

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }


    }
}
