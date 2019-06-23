using FiiApp.Services.DTOs;

namespace FiiApp.Services.SendGridEmailServices
{
    public interface IEmailService
    {
        void SendEmailMessage(FiiAppEmailDto emailDto);
    }
}
