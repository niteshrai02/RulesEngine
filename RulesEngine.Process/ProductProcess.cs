using RulesEngine.Contracts.Request;
using RulesEngine.Contracts.Response;
using RulesEngine.Process.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Process
{
    public class ProductProcess : IProductProcess
    {
        internal readonly IAgentPaymentProcess _agentPaymentProcess;
        public ProductProcess(IAgentPaymentProcess agentPaymentProcess)
        {
            _agentPaymentProcess = agentPaymentProcess ?? throw new ArgumentNullException("agentPaymentProcess Object cannot be null");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRequest"></param>
        /// <returns></returns>
        public async Task<BuyProductResponse> GeneratePackingSlip(BuyProductRequest productRequest)
        {
            var response = new BuyProductResponse()
            {
                PackingSlipShipment = new PackingSlip()
                {
                    ProductName = productRequest.Name,
                    ShippingAddress = productRequest.CustomerDetails.ShippingAddress,
                    CustomerName = productRequest.CustomerDetails.Name
                },
                AgentPaymentDetails = await _agentPaymentProcess.GenerateAgentPayment(ProductType.Physical)
            };
            return response;
            
        }
    }
}
