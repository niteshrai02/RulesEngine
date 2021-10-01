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
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("GeneratePackingSlip")]
        [ProducesResponseType(typeof(BuyProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BuyProductResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BuyProductResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GeneratePackingSlip([FromBody] BuyProductRequest payload, [FromServices] IProductProcess process)
        {
            var response = await process.GeneratePackingSlip(payload);
            if (response == null) return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return new OkObjectResult(response);
        }
    }
}
