using System.Threading.Tasks;

namespace Project_SPA.Mail.Domain
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
