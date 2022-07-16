using BestPractices.Domain.Entities.Email;

namespace BestPractices.ApplicationService.Interfaces.EmailService
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(SystemEmail email);
    }
}
