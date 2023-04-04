using Carental.Configuration.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carental.Configuration
{
    public static class Startup
    {
        public static IConfigurationBuilder AddConfigurations(this IConfigurationBuilder configurationBuilder)
        {
            #region New IConfiguration
            IConfigurationBuilder newConfigurationBuilder = new ConfigurationBuilder();

            string BaseConfigurationDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configurations");
            string[] jsonFiles = Directory.GetFiles(BaseConfigurationDirectory, "*.json");

            foreach (string filePath in jsonFiles)
            {
                configurationBuilder.AddJsonFile(filePath, optional: false, reloadOnChange: true);
            }
            IConfiguration configuration = newConfigurationBuilder.Build();
            #endregion

            configurationBuilder.AddConfiguration(configuration);
            return configurationBuilder;
        }

        public static void AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Smtp>(configuration.GetSection(Smtp.SectionName));
        }
    }
}
