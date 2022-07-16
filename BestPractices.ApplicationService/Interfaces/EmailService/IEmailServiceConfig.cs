using BestPractices.Domain.Entities.Email;

namespace BestPractices.ApplicationService.Interfaces.EmailService
{
    public interface IEmailServiceConfig
    {
        EmailConfig GetEmailConfigurations();
    }
}
