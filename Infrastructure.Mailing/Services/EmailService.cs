using FluentEmail.Core;

namespace Infrastructure.Mailing.Services
{
    public class EmailService
    {

        private IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task Send()
        {
            await _fluentEmail.To("hellO@gmail.com")
            .Body("The body").SendAsync();
        }
    }
}
