using Microsoft.Extensions.Configuration;

namespace Infrastructure.Mailing
{
    public static class Startup
    {
        public static IServiceCollection AddMailingInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            return services;
        }
    }
}
