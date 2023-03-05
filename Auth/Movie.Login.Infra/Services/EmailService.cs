using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using Movie.Login.API.Models;
using Kernel.Domain.Services;
using Movie.Login.Domain.Interfaces;

namespace Movie.Login.API.Services
{
    public class EmailService : IEmailTokenSender
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendTokenOnEmail(string[] strings, string link, int userIdentityId, string code)
        {
            Message message = new Message(strings, link, userIdentityId, code);
            MimeMessage body = CreateEmailBody(message);

            Send(body);
        }

        public void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                       _configuration.GetValue<int>("EmailSettings:Port"), true);

                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));

                    client.Send(mailMessage);
                }
                catch (Exception exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailBody(Message message)
        {
            var messageEmail = new MimeMessage();

            messageEmail.From.Add(new MailboxAddress((_configuration.GetValue<string>("EmailSettings:From"))));
            messageEmail.To.AddRange((message.Recipient));
            messageEmail.Subject = message.Subject;
            messageEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };

            return messageEmail;
        }
    }
}