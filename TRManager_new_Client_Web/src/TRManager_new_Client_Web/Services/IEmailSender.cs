using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRManager_new_Client_Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
