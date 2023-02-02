
using System.Runtime.CompilerServices;

namespace Cobid.Api.Services.MessagingServices.ConversationService;

public interface IConversationService
{
    Task<ServiceResponse<List<Conversation>>> GetAllConversationsAsync();
    Task<ServiceResponse<Conversation>> GetConversationAsync(long conversationId);
    Task<ServiceResponse<List<Conversation>>> GetConversationsByUserId(int userId);
    Task<ServiceResponse<List<Conversation>>> AddConversation(Conversation conversation);
    Task<ServiceResponse<List<Conversation>>> UpdateConversation(Conversation conversation);
    Task<ServiceResponse<List<Conversation>>> DeleteConversation(long conversationId);
    Task<ServiceResponse<Conversation>> GetNewConversation(int userId);
    Task<ServiceResponse<Conversation>> GetExistingConversation(long ProductId, int userId);
    
}
