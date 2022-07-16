using BestPractices.ApplicationService.Interfaces.EmailService;
using BestPractices.Domain.Entities.Email;
using SendGrid;
using SendGrid.Helpers.Mail;
using HtmlAgilityPack;

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
            var sendGridClient = new SendGridClient(_emailConfig.ApiKey);

            var message = new SendGridMessage
            {
                From = new EmailAddress { Email = _emailConfig.From, Name = _emailConfig.Name },
                Subject = email.Subject,
                HtmlContent = email.Body
            };

            message.SetClickTracking(false, false);

            message.AddTo(new EmailAddress { Email = email.To, Name = email.ClientName });

            var sendGridResponse = await sendGridClient.SendEmailAsync(message);

            return sendGridResponse.IsSuccessStatusCode;
        }
    }
}
