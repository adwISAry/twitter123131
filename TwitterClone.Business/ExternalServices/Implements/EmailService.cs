using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.ExternalServices.Interfaces;

namespace TwitterClone.Business.ExternalServices.Implements
{
    public class EmailService : IEmailService
    {
        IConfiguration _configuration { get; }

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string mailTo, string header, string body, bool isHtml = true)
        {
            SmtpClient smtpClient = new(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]))
            {
                EnableSsl = false,
                Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"])
            };

            MailAddress from = new(_configuration["Email:Username"], "Tvitr support team");
            MailAddress to = new(mailTo);

            MailMessage message = new(from, to)
            {
                Body = body,
                Subject = header,
                IsBodyHtml = isHtml
            };

            smtpClient.Send(message);
        }
    }
}
