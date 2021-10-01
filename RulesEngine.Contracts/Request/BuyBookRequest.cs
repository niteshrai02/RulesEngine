using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Contracts.Request
{
    public class BuyBookRequest
    {
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public decimal Price { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
    }
}
