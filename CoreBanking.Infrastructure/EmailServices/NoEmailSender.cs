using CoreBanking.Application.Common;
using CoreBanking.Application.Interfaces.IServices;
using FluentEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Infrastructure.EmailServices
{
    /// <summary>
    /// A No-Op (dummy) email sender used when email service is disabled.
    /// This implements the Null Object Pattern.
    /// </summary>
    public class NoEmailSender : IEmailSenderr
    {

        public Task SendEmailAsync(Message message)
        {
            Console.WriteLine("Email sending disabled.");

            return Task.CompletedTask;
        }
    }
}
