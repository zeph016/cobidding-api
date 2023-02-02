using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommunityMessageController : Controller
    {
        public readonly ICommunityMessageService _communityMessageService;
        private readonly IHubContext<HubConnector, IHubConnector> _hub;
        public CommunityMessageController(ICommunityMessageService communityMessageService, IHubContext<HubConnector, IHubConnector> hub)
        {
            _communityMessageService = communityMessageService;
            _hub = hub;
        }
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<CommunityMessage>>>> GetCommunityMessagesAsync()
        {
            var communityMessage = await _communityMessageService.GetCommunityMessagesAsync();
            return Ok(communityMessage);
        }
        [HttpGet("{communityMessageId}")]
        public async Task<ActionResult<ServiceResponse<CommunityMessage>>> GetCommunityMessageAsync(long communityMessageId)
        {
            var communityMessage = await _communityMessageService.GetCommunityMessageAsync(communityMessageId);
            return Ok(communityMessage);
        }
        [HttpPut("remove/{communityMessageId}")]
        public async Task<ActionResult<ServiceResponse<List<CommunityMessage>>>> RemoveCommunityMessage(long communityMessageId)
        {
            var result = await _communityMessageService.RemoveCommunityMessage(communityMessageId);
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<CommunityMessage>>>> AddCommunityMessage(CommunityMessage communityMessage)
        {
            var result = await _communityMessageService.AddCommunityMessage(communityMessage);
            await _hub.Clients.All.GetNewCommunityPostMessage(true);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<CommunityMessage>>>> UpdateAuctionMessage(CommunityMessage communityMessage)
        {
            var result = await _communityMessageService.UpdateCommunityMessage(communityMessage);
            return Ok(result);
        }
        [HttpGet("all/post={communityPostId}")]
        public async Task<ActionResult<ServiceResponse<List<CommunityMessage>>>> GetCommunityMessagesByPostId(long communityPostId)
        {
            var communityMessage = await _communityMessageService.GetCommunityMessagesByPostId(communityPostId);
            return Ok(communityMessage);
        }
    }

}

