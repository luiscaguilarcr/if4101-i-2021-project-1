using System.Threading.Tasks;

namespace Project_SPA.Models.Domain
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
