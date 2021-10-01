using RulesEngine.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Process.Interface
{
    public interface ISendEmailProcess
    {
        Task<bool> SendEmail(SendEmailRequest emailRequest);
    }
}
