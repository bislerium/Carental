using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace Configuration
{
    public static class Startup
    {
        public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddConfiguration(GetConfiguration());
            return configurationBuilder;
        }

        private static IConfiguration GetConfiguration()
        {
            string BaseConfigurationDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configurations");

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            string[] jsonFiles = Directory.GetFiles(BaseConfigurationDirectory, "*.json");
            foreach (string filePath in jsonFiles)
            {
                configurationBuilder.AddJsonFile(filePath, optional: false, reloadOnChange: true);
            }           
            return configurationBuilder.Build();
        }
    }
}
