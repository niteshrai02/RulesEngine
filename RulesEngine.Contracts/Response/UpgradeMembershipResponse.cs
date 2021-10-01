using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Contracts.Response
{
    public class UpgradeMembershipResponse
    {
        public string Message { get; set; }
        public bool IsUpgraded { get; set; }
    }
}
