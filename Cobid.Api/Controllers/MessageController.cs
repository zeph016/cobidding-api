using Cobid.Api.Connector;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IHubContext<HubConnector, IHubConnector> _hub;
    public MessageController(IMessageService messageService, IHubContext<HubConnector, IHubConnector> hub)
    {
        _messageService = messageService;
        _hub = hub;
    }

    [HttpGet("all")]
    public async Task<ActionResult<ServiceResponse<List<Message>>>> GetAllMessagesAsync()
    {
        var messages = await _messageService.GetAllMessagesAsync();
        return Ok(messages);
    }
    [HttpGet("{messageId}")]
    public async Task<ActionResult<ServiceResponse<Message>>> GetMessageAsync(long messageId)
    {
        var result = await _messageService.GetMessageAsync(messageId);
        return Ok(result);
    }
    [HttpDelete("delete/{messageId}")]
    public async Task<ActionResult<ServiceResponse<List<Message>>>> DeleteMessage(long messageId)
    {
        var result = await _messageService.DeleteMessage(messageId);
        return Ok(result);
    }
    [HttpPost("add")]
    public async Task<ActionResult<ServiceResponse<List<Message>>>> AddMessage(Message message)
    {
        var result = await _messageService.AddMessage(message);
        return Ok(result);
    }
    [HttpPut("update")]
    public async Task<ActionResult<ServiceResponse<List<Message>>>> UpdateMessage(Message message)
    {
        var result = await _messageService.UpdateMessage(message);
        return Ok(result);
    }
    [HttpPut("disable/message={messageId}")]
    public async Task<ActionResult<ServiceResponse<List<Message>>>> DisableMessage(long messageId)
    {
        var result = await _messageService.DeleteMessage(messageId);
        return Ok(result);
    }
    [HttpGet("last/conv={conversationId}")]
    public async Task<ActionResult<ServiceResponse<Message>>> GetLastMessage(long conversationId)
    {
        var result = await _messageService.GetLastMessage(conversationId);
        await _hub.Clients.All.GetLastMessage(result);
        return Ok(result);
    }
}
