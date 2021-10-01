using RulesEngine.Contracts.Request;
using RulesEngine.Contracts.Response;
using RulesEngine.Process.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Process
{
    public class BookProcess : IBookProcess
    {
        internal readonly IAgentPaymentProcess _agentPaymentProcess;
        public BookProcess(IAgentPaymentProcess agentPaymentProcess)
        {
            _agentPaymentProcess = agentPaymentProcess;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookRequest"></param>
        /// <returns></returns>
        public async Task<BuyBookResponse> GenerateDuplicatePackingSlip(BuyBookRequest bookRequest)
        {
            var response = new BuyBookResponse()
            {
                PackingSlipShipment = new PackingSlip()
                {
                    ProductName = bookRequest.Name,
                    ShippingAddress = bookRequest.CustomerDetails.ShippingAddress,
                    CustomerName = bookRequest.CustomerDetails.Name
                },
                AgentPaymentDetails = await _agentPaymentProcess.GenerateAgentPayment(ProductType.Book)
            };
            return response;
        }
    }
}
