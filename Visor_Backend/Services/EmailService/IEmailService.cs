using Microsoft.AspNetCore.Mvc;
using Visor_Backend.Models;

namespace Visor_Backend.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);

        void SendOpinion(EmailDto request);
    }
}
