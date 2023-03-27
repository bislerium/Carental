using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace Configuration
{
    public static class Startup
    {
        public const string CONNECTION_STRINGS = "ConnectionStrings.json";

        public static IConfiguration GetConfiguration() {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configurations"))
                .AddJsonFile(CONNECTION_STRINGS, optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}
