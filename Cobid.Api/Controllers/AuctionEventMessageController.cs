using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionEventMessageController : ControllerBase
    {
        private readonly IAuctionMessageService _auctionMessageService;
        private readonly IHubContext<HubConnector, IHubConnector> _hub;
        public AuctionEventMessageController(IAuctionMessageService auctionMessageService, IHubContext<HubConnector, IHubConnector> hub)
        {
            _auctionMessageService = auctionMessageService;
            _hub = hub;
        }
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<AuctionMessage>>>> GetAuctionMessagesAsync()
        {
            var auctionMessage = await _auctionMessageService.GetAuctionMessagesAsync();
            return Ok(auctionMessage);
        }
        [HttpGet("{auctionMessageId}")]
        public async Task<ActionResult<ServiceResponse<AuctionMessage>>> GetAuctionMessageAsync(long auctionMessageId)
        {
            var auctionMessage = await _auctionMessageService.GetAuctionMessageAsync(auctionMessageId);
            return Ok(auctionMessage);
        }
        [HttpPut("remove/{auctionMessageId}")]
        public async Task<ActionResult<ServiceResponse<List<AuctionMessage>>>> RemoveAuctionMessage(long auctionMessageId)
        {
            var result = await _auctionMessageService.RemoveAuctionMessage(auctionMessageId);
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<AuctionMessage>>>> AddAuctionMessage(AuctionMessage auctionMessage)
        {
            var result = await _auctionMessageService.AddAuctionMessage(auctionMessage);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<AuctionMessage>>>> UpdateAuctionMessage(AuctionMessage auctionMessage)
        {
            var result = await _auctionMessageService.UpdateAuctionMessage(auctionMessage);
            return Ok(result);
        }
        [HttpGet("last/auctconv={auctionEventId}")]
        public async Task<ActionResult<ServiceResponse<Message>>> GetLGetLastAuctionEventMessageastMessage(long auctionEventId)
        {
            var result = await _auctionMessageService.GetLastAuctionEventMessage(auctionEventId);
            await _hub.Clients.All.GetNewAuctionEventMessage(result);
            return Ok(result);
        }
        [HttpGet("highest-bid/auctconv={auctionEventId}")]
        public async Task<ActionResult<decimal>> GetHighestBidCalc(long auctionEventId)
        {
            var result = await _auctionMessageService.GetHighestBidCalc(auctionEventId);
            await _hub.Clients.All.GetHighestAuctionBuid(true);
            return Ok(result);
        }

    }
}
