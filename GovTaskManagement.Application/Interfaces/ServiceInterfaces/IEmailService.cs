using System.Threading.Tasks;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
        Task SendTemplatedEmailAsync<T>(string to, string subject, string templateName, T model);
    }
}
