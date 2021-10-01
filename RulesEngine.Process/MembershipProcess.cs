using RulesEngine.Contracts.Request;
using RulesEngine.Contracts.Response;
using RulesEngine.Process.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Process
{
    public class MembershipProcess : IMembershipProcess
    {
        internal readonly ISendEmailProcess _sendEmailProcess; 
        public MembershipProcess(ISendEmailProcess sendEmailProcess)
        {
            _sendEmailProcess = sendEmailProcess ?? throw new ArgumentNullException("Send EMail Process Object cannot be null");
        }
        public async Task<ActivateMembershipResponse> ActivateMembership(ActivateMembershipRequest activateMembershipRequest)
        {
            //Save the data in the DB and send email
            SendEmailRequest emailRequest = new SendEmailRequest()
            {
                UserName = activateMembershipRequest.UserName,
                Email = activateMembershipRequest.Email,
                Subject = "Membership Activated",
                MembershipType = activateMembershipRequest.MembershipType,
                MembershipValidity = activateMembershipRequest.MembershipValidity
            };
            var response = new ActivateMembershipResponse();
            if (await _sendEmailProcess.SendEmail(emailRequest))
            {
                response = new ActivateMembershipResponse()
                {
                    Message = "Membership is activated for user " + activateMembershipRequest.UserName,
                    IsActivated = true
                };
            }
            
            return response;
        }
        public async Task<UpgradeMembershipResponse> UpgradeMembership(UpgradeMembershipRequest upgradeMembershipRequest)
        {
            SendEmailRequest emailRequest = new SendEmailRequest()
            {
                UserName = upgradeMembershipRequest.UserName,
                Email = upgradeMembershipRequest.Email,
                Subject = "Membership Activated",
                MembershipType = upgradeMembershipRequest.UpgradeType
            };
            var response = new UpgradeMembershipResponse();
            if (await _sendEmailProcess.SendEmail(emailRequest))
            {
                response = new UpgradeMembershipResponse()
                {
                    Message = "Membership is upgraded for user " + upgradeMembershipRequest.UserName,
                    IsUpgraded = true
                };
            }
            
            return response;
        }

        
    }
}
