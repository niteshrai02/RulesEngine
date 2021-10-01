using RulesEngine.Contracts.Request;
using RulesEngine.Process.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Process
{
    public class SendEmailProcess : ISendEmailProcess
    {
        public async Task<bool> SendEmail(SendEmailRequest emailRequest)
        {
            //Call some method which will send email
            bool result = true;
            return result;
        }
    }
}
