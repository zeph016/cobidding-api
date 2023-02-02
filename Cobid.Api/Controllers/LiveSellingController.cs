using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveSellingController : ControllerBase
    {
        private readonly ILiveSellingService _liveSellingService;
        public LiveSellingController(ILiveSellingService liveSellingService) => _liveSellingService = liveSellingService;

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<LiveSelling>>>> GetLiveSellings()
        {
            var liveSellings = await _liveSellingService.GetLiveSellings();
            return Ok(liveSellings);
        }

        [HttpGet("{liveSellingId}")]
        public async Task<ActionResult<ServiceResponse<LiveSelling>>> GetLiveSelling(long liveSellingId)
        {
            var liveSelling = await _liveSellingService.GetLiveSelling(liveSellingId);
            return Ok(liveSelling);
        }

        [HttpDelete("delete/{id}"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<LiveSelling>>>> DeleteLiveSelling(long liveSellingId)
        {
            var result = await _liveSellingService.DeleteLiveSelling(liveSellingId);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<LiveSelling>>>> AddLiveSelling(LiveSelling liveSelling)
        {
            var result = await _liveSellingService.AddLiveSelling(liveSelling);
            return Ok(result);
        }

        [HttpPut("update"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<LiveSelling>>>> UpdateLiveSelling(LiveSelling liveSelling)
        {
            var result = await _liveSellingService.UpdateLiveSelling(liveSelling);
            return Ok(result);
        }
    }
}
