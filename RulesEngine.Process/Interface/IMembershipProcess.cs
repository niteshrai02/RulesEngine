using RulesEngine.Contracts.Request;
using RulesEngine.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Process.Interface
{
    public interface IMembershipProcess
    {
        Task<ActivateMembershipResponse> ActivateMembership(ActivateMembershipRequest activateMembershipRequest);
        Task<UpgradeMembershipResponse> UpgradeMembership(UpgradeMembershipRequest upgradeMembershipRequest);       
    }
}
