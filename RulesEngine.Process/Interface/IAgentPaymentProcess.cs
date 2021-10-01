using RulesEngine.Contracts.Request;
using RulesEngine.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Process.Interface
{
    public interface IAgentPaymentProcess
    {
        Task<AgentPayment> GenerateAgentPayment(ProductType productType);
    }
}
