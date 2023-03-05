using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace Movie.Login.API.Models
{
    public class Message
    {
        public List<MailboxAddress> Recipient { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> recipient, string subject, int userId, string token)
        {
            Recipient = new List<MailboxAddress>();
            Recipient.AddRange(recipient.Select(d => new MailboxAddress(d)));
            Subject = subject;
            Content = $"https://localhost:6001/activate?UserId={userId}&ActivationToken={token}";
        }
    }
}