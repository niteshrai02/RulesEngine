using RulesEngine.Contracts.Request;
using RulesEngine.Contracts.Response;
using RulesEngine.Process.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Process
{
    public class AgentPaymentProcess : IAgentPaymentProcess
    {
        public async Task<AgentPayment> GenerateAgentPayment(ProductType productType)
        {
            var response = new AgentPayment();
            switch (productType.ToString())
            {
                case "Physical":
                    response = new AgentPayment()
                    {
                        AgentName = "Test",
                        PaymentAmount = 10.00M
                    };
                    break;
                case "Book":
                    response = new AgentPayment()
                    {
                        AgentName = "Test",
                        PaymentAmount = 10.00M
                    };
                    break;

            }
            
            return response;
        }
    }
}
