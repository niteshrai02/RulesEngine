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
    public class BookController : ControllerBase
    {
        [HttpPost]
        [Route("GenerateDuplicatePackingSlip")]
        [ProducesResponseType(typeof(BuyBookResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BuyBookResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BuyBookResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateDuplicatePackingSlip([FromBody] BuyBookRequest payload, [FromServices] IBookProcess process)
        {
            var response = await process.GenerateDuplicatePackingSlip(payload);
            if (response == null) return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return new OkObjectResult(response);
        }
    }
}
