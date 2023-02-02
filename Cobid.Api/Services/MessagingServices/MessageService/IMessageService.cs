namespace Cobid.Api.Services.MessagingServices.MessageService;

public interface IMessageService
{
    Task<ServiceResponse<List<Message>>> GetAllMessagesAsync();
    Task<ServiceResponse<Message>> GetMessageAsync(long messageId);
    Task<ServiceResponse<List<Message>>> AddMessage(Message message);
    Task<ServiceResponse<List<Message>>> UpdateMessage(Message message);
    Task<ServiceResponse<List<Message>>> DeleteMessage(long messageId);
    Task<ServiceResponse<Message>> GetLastMessage(long messageId);
}
