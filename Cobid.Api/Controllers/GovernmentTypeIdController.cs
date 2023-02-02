using Cobid.Api.Services.EnumsService.GovernmentIdService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GovernmentTypeIdController : ControllerBase
    {
        private readonly IGovernmentIdService _governmentIdService;
        public GovernmentTypeIdController(IGovernmentIdService governmentIdService) => _governmentIdService = governmentIdService;
        [HttpGet("all-govid")]
        public async Task<ActionResult<ServiceResponse<List<GovernmentIdService>>>> GetAllGovIdTypes()
        {
            var governmentIds = await _governmentIdService.GetAllGovIdTypes();
            return Ok(governmentIds);
        }
    }
}
