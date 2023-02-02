
using Cobid.Api.Connector;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionEventParticipantController : ControllerBase
    {
        private readonly IAuctionParticipantService _auctionParticipantService;
        private readonly IHubContext<HubConnector, IHubConnector> _hub;
        public AuctionEventParticipantController(IAuctionParticipantService auctionParticipantService, IHubContext<HubConnector, IHubConnector> hub)
        {
            _auctionParticipantService = auctionParticipantService;
            _hub = hub;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<AuctionEventParticipant>>>> GetAllParticipantsAsync()
        {
            var auctionEventParticipants = await _auctionParticipantService.GetAllParticipantsAsync();
            return Ok(auctionEventParticipants);
        }
        [HttpGet("{auctionEventParticipantId}")]
        public async Task<ActionResult<ServiceResponse<List<AuctionEventParticipant>>>> GetAuctionEventParticipant(long auctionEventParticipantId)
        {
            var auctionEventParticipant = await _auctionParticipantService.GetAuctionEventParticipant(auctionEventParticipantId);
            return Ok(auctionEventParticipant);
        }
        [HttpPost("remove")]
        public async Task<ActionResult<ServiceResponse<List<AuctionEventParticipant>>>> RemoveAuctionEventParticipant(AuctionEventParticipant auctionEventParticipant)
        {
            var result = await _auctionParticipantService.RemoveAuctionEventParticipant(auctionEventParticipant);
            await _hub.Clients.All.CountParticipants(true);
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<AuctionEventParticipant>>>> AddAuctionEventParticipant(AuctionEventParticipant auctionEventParticipant)
        {
            var result = await _auctionParticipantService.AddAuctionEventParticipant(auctionEventParticipant);
            await _hub.Clients.All.CountParticipants(true);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<AuctionEventParticipant>>>> UpdateAuctionEventParticipant(AuctionEventParticipant auctionEventParticipant)
        {
            var result = await _auctionParticipantService.UpdateAuctionEventParticipant(auctionEventParticipant);
            await _hub.Clients.All.CountParticipants(true);
            return Ok(result);
        }
        [HttpGet("count/auction={auctionEventId}")]
        public async Task<ActionResult<int>> CountParticipantsByAuctionId(long auctionEventId)
        {
            var result = await _auctionParticipantService.CountParticipantsByAuctionId(auctionEventId);
            return Ok(result);
        }

        [HttpGet("auction={auctionEventId}/user={userId}")]
        public async Task<ActionResult<ServiceResponse<List<AuctionEventParticipant>>>> GetAuctionEventParticipantByUserId(long auctionEventId, int userId)
        {
            var auctionEventParticipant = await _auctionParticipantService.GetAuctionEventParticipantByUserId(auctionEventId, userId);
            return Ok(auctionEventParticipant);
        }
    }
}
