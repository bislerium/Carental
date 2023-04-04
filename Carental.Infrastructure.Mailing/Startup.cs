using Carental.Configuration.Options;
using System.Net.Mail;
using System.Net;
using Carental.Application.Interfaces.Mailing;
using Carental.Infrastructure.Mailing.Services;

namespace Carental.Infrastructure.Mailing
{
    public static class Startup
    {
        public static IServiceCollection AddMailingInfrastructure(this IServiceCollection services, Smtp smtp) {

            var senderClient = new SmtpClient(smtp.Server)
            {
                UseDefaultCredentials = false,
                Port = smtp.Port,
                EnableSsl = smtp.IsSsl,
                Credentials = new NetworkCredential(smtp.Username, smtp.Password)
            };

            services
                .AddFluentEmail(smtp.From)
                .AddRazorRenderer()
                .AddSmtpSender(senderClient);

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
