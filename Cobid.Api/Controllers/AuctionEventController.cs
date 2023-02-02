using Cobid.Api.Connector;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionEventController : ControllerBase
    {
        private readonly IAuctionService _auctionService;
        private readonly IHubContext<HubConnector, IHubConnector> _hub;
        public AuctionEventController(IAuctionService auctionService, IHubContext<HubConnector, IHubConnector> hub)
        {
            _auctionService = auctionService;
            _hub = hub;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<AuctionEvent>>>> GetAuctionEventsAsync()
        {
            var auctionEvents = await _auctionService.GetAuctionEventsAsync();
            return Ok(auctionEvents);
        }
        [HttpGet("{auctionEventId}")]
        public async Task<ActionResult<ServiceResponse<AuctionEvent>>> GetAuctionEventsAsync(long auctionEventId)
        {
            var auctionEvent = await _auctionService.GetAuctionEventsAsync(auctionEventId);
            return Ok(auctionEvent);
        }
        [HttpDelete("delete/auction/{auctionEventId}"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<AuctionEvent>>>> DeleteAuctionEvent(long auctionEventId)
        {
            var result = await _auctionService.DeleteAuctionEvent(auctionEventId);
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<AuctionEvent>>>> AddAuctionEvent(AuctionEvent auctionEvent)
        {
            var result = await _auctionService.AddAuctionEvent(auctionEvent);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<AuctionEvent>>>> UpdateAuctionEvent(AuctionEvent AuctionEvent)
        {
            var result = await _auctionService.UpdateAuctionEvent(AuctionEvent);
            await _hub.Clients.All.UpdateAuctionEvent(true);
            return Ok(result);
        }
    }
}
