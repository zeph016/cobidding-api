using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cobid.Api.Services.CommunityService.CommunityPostService;
using Cobid.Api.Entities.Community;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommunityPostController : ControllerBase
    {
        private readonly ICommunityPostService _communityPostService;
        private readonly IHubContext<HubConnector, IHubConnector> _hub;
        public CommunityPostController(ICommunityPostService communityPostService, IHubContext<HubConnector, IHubConnector> hub)
        {
           _communityPostService= communityPostService;
            _hub = hub;
        }
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<CommunityPost>>>> GetCommunityPostsAsync()
        {
            var communityPost = await _communityPostService.GetCommunityPostsAsync();
            return Ok(communityPost);
        }
        [HttpGet("{communityPostId}")]
        public async Task<ActionResult<ServiceResponse<CommunityPost>>> GetCommunityPostAsync(long communityPostId)
        {
            var communityPost = await _communityPostService.GetCommunityPostAsync(communityPostId);
            return Ok(communityPost);
        }
        [HttpPut("remove/{communityPostId}")]
        public async Task<ActionResult<ServiceResponse<List<CommunityPost>>>> RemoveCommunityPost(long communityPostId)
        {
            var result = await _communityPostService.RemoveCommunityPost(communityPostId);
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<CommunityPost>>>> AddCommunityPost(CommunityPost communityPost)
        {
            var result = await _communityPostService.AddCommunityPost(communityPost);
            await _hub.Clients.All.GetNewCommunityPost(true);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<CommunityPost>>>> UpdateCommunityPost(CommunityPost communityPost)
        {
            var result = await _communityPostService.UpdateCommunityPost(communityPost);
            return Ok(result);
        }

    }
}
