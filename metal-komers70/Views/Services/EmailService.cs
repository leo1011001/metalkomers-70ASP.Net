using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace metal_komers70.Views.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendContactFormAsync(string name, string email, string phone, string message)
        {
            var smtpHost = _config["EmailSettings:Host"];
            var smtpPort = int.Parse(_config["EmailSettings:Port"]);
            var smtpUser = _config["EmailSettings:Username"];
            var smtpPass = _config["EmailSettings:Password"];
            var adminEmail = _config["EmailSettings:AdminEmail"];

            using var client = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUser),
                Subject = $"New Contact Form Submission from {name}",
                Body = $"Name: {name}\nEmail: {email}\nPhone: {phone}\nMessage: {message}",
                IsBodyHtml = false
            };
            mailMessage.To.Add(adminEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}
