using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace ITRoot_Task.Helper
{
    public static class EmailHelper
    {
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            await Execute(ConfigurationManager.AppSettings["SendGridKey"], subject, message, email);
        }

        public static async Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("m.abdelfatah@nasps.org.eg", ConfigurationManager.AppSettings["SendGridUser"]),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

             await client.SendEmailAsync(msg);
        }
    }
}