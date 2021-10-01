using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Contracts.Request
{
    public class BuyProductRequest
    {
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public decimal Price { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
    }
    public enum ProductType
    {
        Physical,
        Book
    }
    public class CustomerDetails
    {
        public string ShippingAddress { get; set; }
        public string Name { get; set; }
    }
}
