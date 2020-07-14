using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace hikeforyourselfver3.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, string attachments)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "HikeForYourself");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        internal void RegisterAPIKey()
        {
            throw new NotImplementedException();
        }

        internal void Send(string toEmail, string subject, string contents)
        {
            throw new NotImplementedException();
        }
    }
}