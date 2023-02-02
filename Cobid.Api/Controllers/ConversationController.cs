using Cobid.Api.Connector;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Cobid.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ConversationController : ControllerBase
{
    private readonly IConversationService _conversationService;
    private readonly IHubContext<HubConnector, IHubConnector> _hub;
    public ConversationController(IConversationService conversationService, IHubContext<HubConnector, IHubConnector> hub)
    {
        _conversationService = conversationService;
        _hub = hub;
    }

    [HttpGet("all")]
    public async Task<ActionResult<ServiceResponse<List<Conversation>>>> GetAllConversationsAsync()
    {
        var conversations = await _conversationService.GetAllConversationsAsync();
        return Ok(conversations);
    }
    [HttpGet("{conversationId}")]
    public async Task<ActionResult<ServiceResponse<Conversation>>> GetConversationAsync(long conversationId)
    {
        var result = await _conversationService.GetConversationAsync(conversationId);
        return Ok(result);
    }
    [HttpDelete("delete/{conversationId}")]
    public async Task<ActionResult<ServiceResponse<List<Conversation>>>> DeleteConversation(long conversationId)
    {
        var result = await _conversationService.DeleteConversation(conversationId);
        return Ok(result);
    }
    [HttpPost("add")]
    public async Task<ActionResult<ServiceResponse<List<Conversation>>>> AddConversation(Conversation conversation)
    {
        var result = await _conversationService.AddConversation(conversation);
        return Ok(result);
    }
    [HttpPut("update")]
    public async Task<ActionResult<ServiceResponse<List<Conversation>>>> UpdateConversation(Conversation conversation)
    {
        var result = await _conversationService.UpdateConversation(conversation);
        return Ok(result);
    }
    [HttpPut("disable/conversation={conversationId}")]
    public async Task<ActionResult<ServiceResponse<List<Conversation>>>> DissableMessage(long conversationId)
    {
        var result = await _conversationService.DeleteConversation(conversationId);
        return Ok(result);
    }
    [HttpGet("get/{userId}")]
    public async Task<ActionResult<ServiceResponse<Conversation>>> GetConversationsByUserId(int userId)
    {
        var result = await _conversationService.GetConversationsByUserId(userId);
        return Ok(result);
    }
    [HttpGet("new/{userId}")]
    public async Task<ActionResult<ServiceResponse<Conversation>>> GetNewConversation(int userId)
    {
        var result = await _conversationService.GetNewConversation(userId);
        await _hub.Clients.All.GetNewConversation(result);
        return Ok(result);
    }
    [HttpGet("get/exist/{productId}/{userId}")]
    public async Task<ActionResult<ServiceResponse<Conversation>>> GetExistingConversation(long productId, int userId)
    {
        var result = await _conversationService.GetExistingConversation(productId, userId);
        return Ok(result);
    }
}
