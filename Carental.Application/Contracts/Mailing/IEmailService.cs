using Carental.Application.DTOs.Mailing;
using System.Net.Mail;

namespace Carental.Application.Interfaces.Mailing
{
    public interface IEmailService
    {
        public Task SendAsync(EmailMessage message);
    }
}
