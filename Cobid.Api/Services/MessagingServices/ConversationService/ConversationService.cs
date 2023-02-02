using Cobid.Api.Entities.Messaging;
using Cobid.Api.Entities.Product;
using System.Runtime.CompilerServices;

namespace Cobid.Api.Services.MessagingServices.ConversationService;

public class ConversationService : IConversationService
{
    private readonly CobidDbContext _context;
    public ConversationService(CobidDbContext context) => _context = context;
    public async Task<ServiceResponse<List<Conversation>>> AddConversation(Conversation conversation)
    {
        conversation.IsRead = false;
        conversation.IsActive = true;
        _context.Conversations.Add(conversation);
        await _context.SaveChangesAsync();
        return await GetAllConversationsAsync();
    }

    public async Task<ServiceResponse<List<Conversation>>> DeleteConversation(long conversatonId)
    {
        Conversation conversation = await GetConversationById(conversatonId);
        if (conversation == null)
        {
            return new ServiceResponse<List<Conversation>>
            {
                Success = false,
                Message = "Conversation not found"
            };
        }
        //Disable conversation
        conversation.IsActive = false;
        await _context.SaveChangesAsync();
        return await GetAllConversationsAsync();
    }

    public async Task<Conversation> GetConversationById(long conversatonId)
    {
        return await _context.Conversations.FirstOrDefaultAsync(x => x.ConversationId == conversatonId) ?? new();
    }

    public async Task<ServiceResponse<Conversation>> GetConversationAsync(long conversationId)
    {
        var response = new ServiceResponse<Conversation>();
        var conversation = await _context.Conversations.Include(x => x.Messages.Where(y => y.ConversationId == conversationId)).FirstOrDefaultAsync(x => x.ConversationId == conversationId);
        if (conversation == null)
        {
            response.Success = false;
            response.Message = "Conversation not found";
        }
        else
            response.Data = conversation;
        return response;
    }

    public async Task<ServiceResponse<Conversation>> GetNewConversation(int userId)
    {
        var response = new ServiceResponse<Conversation>();
        var conversation = await _context.Conversations.Where(x => x.CreatedById == userId ||  x.ReceiverId == userId).OrderByDescending(y=>y.ConversationId).FirstOrDefaultAsync(); ;
        if (conversation == null)
        {
            response.Success = false;
            response.Message = "Conversation not found";
        }
        else
            response.Data = await _context.Conversations.Include(x => x.Messages.Where(y => y.ConversationId == conversation.ConversationId)).FirstOrDefaultAsync(x => x.ConversationId == conversation.ConversationId);
        return response;
    }
    public async Task<ServiceResponse<Conversation>> GetExistingConversation(long productId, int userid)
    {
        var response = new ServiceResponse<Conversation>();
        var conversation = await _context.Conversations.Where(x => x.ProductId == productId && x.CreatedById == userid).OrderByDescending(y => y.ConversationId).FirstOrDefaultAsync(); ;
        if (conversation == null)
        {
            response.Success = false;
            response.Message = "Conversation not found";
        }
        else
            response.Data = await _context.Conversations.Include(x => x.Messages.Where(y => y.ConversationId == conversation.ConversationId)).FirstOrDefaultAsync(x => x.ConversationId == conversation.ConversationId);
        return response;
    }
    public async Task<ServiceResponse<List<Conversation>>> GetAllConversationsAsync()
    {
        var response = new ServiceResponse<List<Conversation>>
        { Data = await _context.Conversations.Where(x => x.IsActive).ToListAsync() };
        return response;
    }
    public async Task<ServiceResponse<List<Conversation>>> GetConversationsByUserId(int userId)
    {
        var response = new ServiceResponse<List<Conversation>>
        {
            Data = await _context.Conversations.Where(x => x.IsActive && x.CreatedById == userId || x.ReceiverId == userId).Include(y=>y.Messages).ToListAsync()
        };
        return response;
    }

    public async Task<ServiceResponse<List<Conversation>>> UpdateConversation(Conversation conversation)
    {
        var dbConversation = await GetConversationById(conversation.ConversationId);
        if(dbConversation == null)
        {
            return new ServiceResponse<List<Conversation>>
            {
                Success = false,
                Message = "Conversation not found."
            };
        }

        dbConversation.ProductId = conversation.ProductId;
        dbConversation.CreatedById = conversation.CreatedById;
        dbConversation.ReceiverId = conversation.ReceiverId;
        dbConversation.Messages = conversation.Messages;
        dbConversation.DateCreated = conversation.DateCreated;
        dbConversation.ConversationTitle = conversation.ConversationTitle;
        dbConversation.IsRead = conversation.IsRead;
        dbConversation.IsActive = conversation.IsActive;

        await _context.SaveChangesAsync();
        return await GetAllConversationsAsync();
    }
}
