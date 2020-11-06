using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCapstone.Services.Messaging
{
    public class MessageService : IMessageService
    {
        public async Task SendEmailAsync(
            string fromDisplayName, 
            string fromEmailAddress, 
            string toName, 
            string toEmailAddress, 
            string subject, 
            string message) 
            //params Attachment[] attachments)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromDisplayName, fromEmailAddress));
            email.To.Add(new MailboxAddress(toName, toEmailAddress));
            email.Subject = subject;

            var body = new BodyBuilder
            {
                HtmlBody = message
            };
            //foreach (var attachment in attachments)
            //{
               // using (var stream = await attachment.ContentToStreamAsync())
                //{
                   // body.Attachments.Add(attachment.FileName, stream);
                //}
            //}

            email.Body = body.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback =
                    (sender, certificate, certChainType, errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                //need actual google information for gmail below:
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTlsWhenAvailable).ConfigureAwait(true);
                await client.AuthenticateAsync("group.capstone123@gmail.com", "Test123!").ConfigureAwait(true);

                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
