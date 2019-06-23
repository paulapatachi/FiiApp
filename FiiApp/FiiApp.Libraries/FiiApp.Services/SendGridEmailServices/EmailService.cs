using FiiApp.Services.DTOs;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FiiApp.Services.SendGridEmailServices
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendEmailMessage(FiiAppEmailDto emailDto)
        {
            var sendGrid = new Dictionary<string, string>
            {
                {"smtp", configuration.GetSection("SendGrid:smtp").Value},
                {"username", configuration.GetSection("SendGrid:username").Value},
                {"password", configuration.GetSection("SendGrid:password").Value}
            };

            var emailObj = new MailMessage
            {
                From = new MailAddress(emailDto.FromEmail, emailDto.FromName),
                Subject = emailDto.Subject,
                Body = emailDto.Body,
                IsBodyHtml = false
            };

            foreach (var toEmail in emailDto.ToEmail)
            {
                emailObj.To.Add(toEmail);
            }
            if (emailDto.ToEmail.Count() > 0)
            {
                foreach (var ccEmail in emailDto.CcEmail)
                {
                    emailObj.CC.Add(ccEmail);
                }
            }

            foreach (var attach in emailDto.Attachments)
            {
                var stream = new MemoryStream(Encoding.Unicode.GetBytes(attach.Value));
                // the name of the file should include extension (ex: pdf, xml, doc)
                var fileName = attach.Name;
                var attachment = new Attachment(stream, fileName);
                emailObj.Attachments.Add(attachment);
            }

            SendEmail(emailObj, sendGrid);
        }

        private void SendEmail(MailMessage mailMessage, Dictionary<string, string> sendGrid)
        {
            var smtpClient = new SmtpClient(sendGrid["smtp"], 587);
            smtpClient.Credentials = new NetworkCredential(sendGrid["username"], sendGrid["password"]); ;
            smtpClient.Send(mailMessage);
        }
    }
}
