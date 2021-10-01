using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Contracts.Request
{
    public class UpgradeMembershipRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public MembershipType UpgradeType { get; set; }
    }
}
