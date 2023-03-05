using MimeKit;
using System.Collections.Generic;
using Movie.Login.API.Models;

namespace Movie.Login.Domain.Model.Models
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message Message { get; set; }
        public MailboxAddress From { get; set; }
        public List<MailboxAddress> To { get; set; }
    }
}
