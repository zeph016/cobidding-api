using Cobid.Api.Entities.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Cobid.Api.Services.MessagingServices.MessageService;

public class MessageService : IMessageService
{
    private readonly CobidDbContext _context;
    public MessageService(CobidDbContext context) => _context = context;
    public async Task<ServiceResponse<List<Message>>> AddMessage(Message message)
    {
        message.IsRead = false;
        message.IsActive = true;
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return await GetAllMessagesAsync();
    }

    public async Task<ServiceResponse<List<Message>>> DeleteMessage(long messageId)
    {
        Message message = await GetMessageById(messageId);
        if(message == null)
        {
            return new ServiceResponse<List<Message>>
            {
                Success = false,
                Message = "Message not found."
            };
        }
        //Disable
        message.IsActive = false;
        await _context.SaveChangesAsync();
        return await GetAllMessagesAsync();
    }

    public async Task<Message> GetMessageById(long messageId)
    {
        return await _context.Messages.FirstOrDefaultAsync(x => x.MessageId == messageId) ?? new();
    }

    public async Task<ServiceResponse<Message>> GetMessageAsync(long messageId)
    {
        var response = new ServiceResponse<Message>();
        var message = await _context.Messages.FindAsync(messageId);
        if (message == null)
        {
            response.Success = false;
            response.Message = "Message not found";
        }
        else
            response.Data = message;
        return response;
    }

    public async Task<ServiceResponse<Message>> GetLastMessage(long conversationId)
    {
        var response = new ServiceResponse<Message>();
        var message = await _context.Messages.Where(x => x.ConversationId == conversationId).OrderByDescending(x=>x.MessageId).FirstOrDefaultAsync();
        if (message == null)
        {
            response.Success = false;
            response.Message = "Message not found";
        }
        else
            response.Data = message;
        return response;
    }

    public async Task<ServiceResponse<List<Message>>> GetAllMessagesAsync()
    {
        var response = new ServiceResponse<List<Message>>
        { Data = await _context.Messages.Where(x => x.IsActive).ToListAsync() };
        return response;
    }

    public async Task<ServiceResponse<List<Message>>> UpdateMessage(Message message)
    {
        var dbMessage = await GetMessageById(message.MessageId);
        if(dbMessage == null)
        {
            return new ServiceResponse<List<Message>> 
            {
                Success = false,
                Message = "Message not found"
            };
        }

        dbMessage.ConversationId = message.ConversationId;
        dbMessage.SenderId = message.SenderId;
        dbMessage.MessageContent = message.MessageContent;
        dbMessage.ImageData = message.ImageData;
        dbMessage.DateSent = message.DateSent;
        await _context.SaveChangesAsync();
        return await GetAllMessagesAsync();
    }
}
