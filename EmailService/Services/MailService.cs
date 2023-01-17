using Azure.Identity;
using EmailService.Models;
using Microsoft.Graph;

namespace EmailService.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _config;

        public MailService(IConfiguration config)
        {
            _config = config;//to obtain values (DI)
        }
        public async Task SendAsync(GraphMail mail)
        {
            string clientSecret = _config["clientSecret"];
            string clientId = _config["clientId"];
            string tenantId = _config["tenantId"];

            ClientSecretCredential azureCredentials = new(tenantId, clientId, clientSecret);
            GraphServiceClient client = new GraphServiceClient(azureCredentials);

            var message = new Message()
            {
                ToRecipients = new List<Recipient>()
                {
                    new Recipient()
                    {
                        EmailAddress= new EmailAddress()
                        {
                            Address=mail.ToEmail
                        }
                    }
                },
                Subject= mail.Subject,
                Body=new ItemBody()
                {
                    ContentType=mail.ContentType,
                    Content=mail.Content    
                }
            };
            await client.Users[mail.FromEmail].SendMail(message, mail.SaveToSentItems).Request().PostAsync();
            
        }
    }
}
