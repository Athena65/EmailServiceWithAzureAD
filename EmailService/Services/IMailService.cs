using EmailService.Models;

namespace EmailService.Services
{
    public interface IMailService
    {
        Task SendAsync(GraphMail mail);
    }
}
