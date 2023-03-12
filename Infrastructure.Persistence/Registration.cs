using Domain.UnitOfWork;
using Infrastructure.Persistence.Identity;
using uow = Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence
{
    internal static class Registration
    {
        public static void RegisterPersistenceInfrastructure(this IServiceCollection services) 
        {
            services.AddDbContext<AppDBContext>();
            services.AddIdentity();
            services.AddScoped<IUnitOfWork, uow.UnitOfWork>();
        }
    }
}
