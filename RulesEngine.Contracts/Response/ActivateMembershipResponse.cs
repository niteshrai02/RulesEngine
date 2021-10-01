using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Contracts.Response
{
    public class ActivateMembershipResponse
    {
        public string Message { get; set; }
        public bool IsActivated { get; set; }
    }
}
