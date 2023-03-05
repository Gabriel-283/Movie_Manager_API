using MimeKit;

namespace Kernel.Domain.Services
{
    public interface IEmailService
    {
        void Send(MimeMessage mailMessage);
    }
}
