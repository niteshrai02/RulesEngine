using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RulesEngine.Contracts.Request;
using RulesEngine.Contracts.Response;
using RulesEngine.Process.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RulesEngine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        
        [HttpPost]
        [Route("Activate")]
        [ProducesResponseType(typeof(ActivateMembershipResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActivateMembershipResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ActivateMembershipResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Activate([FromBody] ActivateMembershipRequest payload, [FromServices] IMembershipProcess process)
        {
            var response = await process.ActivateMembership(payload);
            if (response == null) return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return new OkObjectResult(response);
        }
        [HttpPost]
        [Route("Upgrade")]
        [ProducesResponseType(typeof(UpgradeMembershipResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UpgradeMembershipResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(UpgradeMembershipResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Upgrade([FromBody] UpgradeMembershipRequest payload, [FromServices] IMembershipProcess process)
        {
            var response = await process.UpgradeMembership(payload);
            if (response == null) return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return new OkObjectResult(response);
        }
    }
}
