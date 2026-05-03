using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using HandlebarsDotNet;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;

namespace GovTaskManagement.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"] ?? "587");
            var smtpUser = _configuration["EmailSettings:SmtpUser"];
            var smtpPass = _configuration["EmailSettings:SmtpPass"];

            var fromEmail = _configuration["EmailSettings:FromEmail"] ?? smtpUser;

            using var client = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(fromEmail!),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(to);

            await client.SendMailAsync(mail);
        }

        public async Task SendTemplatedEmailAsync<T>(string to, string subject, string templateName, T model)
        {
            var templateContent = LoadEmbeddedTemplate(templateName);
            var compiled = Handlebars.Compile(templateContent);
            var body = compiled(model);
            await SendEmailAsync(to, subject, body);
        }

        private string LoadEmbeddedTemplate(string templateName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"GovTaskManagement.Infrastructure.EmailTemplates.{templateName}.hbs";
            using var stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new FileNotFoundException($"Email template '{templateName}.hbs' not found as embedded resource.");
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
