using Microsoft.Extensions.Configuration;

namespace Configuration
{
    public static class Startup
    {
        public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder configurationBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configurations"))
                .AddJsonFile("ConnectionStrings.json", optional: false, reloadOnChange: true)
                .Build();

            configurationBuilder.AddConfiguration(configuration);

            return configurationBuilder;
        }
    }
}
