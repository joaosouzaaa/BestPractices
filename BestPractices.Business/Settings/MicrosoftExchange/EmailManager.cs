using BestPractices.Domain.Entities.Email;

namespace BestPractices.Business.Settings.MicrosoftExchange
{
    public abstract class EmailManager
    {
        protected object Connection { get; set; }
        protected EmailConfig _emailConfig { get; set; }
        abstract public Task<bool> OpenConnection();

        public EmailManager(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }
    }
}
