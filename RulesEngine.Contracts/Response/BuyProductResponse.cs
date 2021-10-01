using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Contracts.Response
{
    public class BuyProductResponse
    {
        public PackingSlip PackingSlipShipment { get; set; }
        public AgentPayment AgentPaymentDetails { get; set; }

    }
    public class PackingSlip
    {
        public string ShippingAddress { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
    }
    public class AgentPayment
    {
        public string AgentName { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
