using BestPractices.Domain.Entities.Email;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace BestPractices.Business.Settings.MicrosoftExchange
{
    public class MicrosoftExchange : EmailManager
    {
        public MicrosoftExchange(EmailConfig emailConfig) : base(emailConfig)
        {
        }

        public override async Task<bool> OpenConnection()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

            var service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);

            base.Connection = service;
                
            service.Credentials = new NetworkCredential(base._emailConfig.From, base._emailConfig.Password);
            
            service.Url = new Uri(base._emailConfig.ServerExchange);

            var findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(1));

            return true;
        }

        public void SendEmail(SystemEmail email)
        {
            var message = new EmailMessage(base.Connection as ExchangeService);
            message.Subject = email.Subject;
            message.Body = new MessageBody(BodyType.HTML, email.Body);
            message.ToRecipients.Add(email.To);

            message.Send();
        }
    }
}
