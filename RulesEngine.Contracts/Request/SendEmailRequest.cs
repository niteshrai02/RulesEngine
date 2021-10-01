using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Contracts.Request
{
    public class SendEmailRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public MembershipType MembershipType { get; set; }
        public MembershipValidity MembershipValidity { get; set; }

    }
}
