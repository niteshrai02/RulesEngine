using RulesEngine.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Contracts.Response
{
    public class BuyBookResponse
    {
        public PackingSlip PackingSlipShipment { get; set; }
        public AgentPayment AgentPaymentDetails { get; set; }
    }
}
