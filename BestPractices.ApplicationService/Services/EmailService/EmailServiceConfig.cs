using BestPractices.ApplicationService.Interfaces.EmailService;
using BestPractices.Domain.Entities.Email;
using Microsoft.Extensions.Options;

namespace BestPractices.ApplicationService.Services.EmailService
{
    public class EmailServiceConfig : IEmailServiceConfig
    {
        private readonly EmailConfig _emailConfig;

        public EmailServiceConfig(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public EmailConfig GetEmailConfigurations()
        {
            return new EmailConfig
            {
                From = _emailConfig.From,
                Password = _emailConfig.Password,
                ServerExchange = _emailConfig.ServerExchange
            };
        }
    }
}
