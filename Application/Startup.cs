using Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly currentAssembly = typeof(Startup).Assembly;

            services.AddValidatorsFromAssembly(currentAssembly);

            services.AddMediatR(configuration => { 
                configuration.RegisterServicesFromAssembly(currentAssembly);
                configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));            
            });

            return services;
        }
    }
}
