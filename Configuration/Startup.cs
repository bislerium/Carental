using Microsoft.Extensions.Configuration;

namespace Configuration
{
    public static class Startup
    {
        public static IConfiguration GetConfiguration() {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath("Configurations");
            builder.AddJsonFile("")
                .AddJsonFile("");
            return builder.Build();
        }
    }
}
