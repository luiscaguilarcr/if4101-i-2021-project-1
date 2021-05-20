using Project_SPA.Models.Domain;
using System.Threading.Tasks;

namespace Project_SPA.Properties.Messaging
{
    interface IEmailService
    {
        bool SendEmail(Email email);
    }
}
