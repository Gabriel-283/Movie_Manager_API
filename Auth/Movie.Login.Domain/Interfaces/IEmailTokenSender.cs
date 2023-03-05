using Kernel.Domain.Services;

namespace Movie.Login.Domain.Interfaces
{
    public interface IEmailTokenSender : IEmailService
    {
        void SendTokenOnEmail(string[] strings, string link, int userIdentityId, string code);
    }
}
