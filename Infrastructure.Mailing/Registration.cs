namespace Infrastructure.Mailing
{
    internal static class Registration
    {
        public static void RegisterMailingInfrastructure(this IServiceCollection services)
        {
            services
            .AddFluentEmail("fromemail@test.test")
            .AddRazorRenderer()
            .AddSmtpSender("localhost", 25);
        }
    }
}
