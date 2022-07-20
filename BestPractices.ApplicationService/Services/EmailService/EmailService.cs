using BestPractices.ApplicationService.Interfaces.EmailService;
using BestPractices.Domain.Entities.Email;
using BestPractices.Business.Settings.MicrosoftExchange;

namespace BestPractices.ApplicationService.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IEmailServiceConfig _emailServiceConfig;
        private readonly EmailConfig _emailConfig;

        public EmailService(IEmailServiceConfig emailServiceConfig)
        {
            _emailServiceConfig = emailServiceConfig;
            _emailConfig = emailServiceConfig.GetEmailConfigurations();
        }

        public async Task<bool> SendEmailAsync(SystemEmail email)
        {
            var exchange = new MicrosoftExchange(_emailConfig);

            if (await exchange.OpenConnection())
            {
                exchange.SendEmail(email);
                return true;
            }

            return false;
        }
    }
}
