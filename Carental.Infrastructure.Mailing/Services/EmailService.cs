using Carental.Application.DTOs.Mailing;
using Carental.Application.Interfaces.Mailing;
using FluentEmail.Core;
using System.Net.Mail;

namespace Carental.Infrastructure.Mailing.Services
{
    public class EmailService: IEmailService
    {

        private readonly IFluentEmail _FluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _FluentEmail = fluentEmail;
        }

        public async Task SendAsync(EmailMessage message)
        {
            var response = await _FluentEmail
                .To(message.To)
                .Subject(message.Subject)
                .Body(message.Body)
                .SendAsync();
            
            if (!response.Successful) {                
                throw new Exception(response.ErrorMessages.ToString());
            }
        }
    }
}
