using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Contracts.Request
{
    public class ActivateMembershipRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public MembershipType MembershipType { get; set; }
        public MembershipValidity MembershipValidity { get; set; }
    }
    public enum MembershipType
    {
        Trial,
        General,
        Premium
    }
    public enum MembershipValidity
    {
       ThreeMonths,
       SixMonths,
       NineMonths,
       TwelveMonths
    }
}
