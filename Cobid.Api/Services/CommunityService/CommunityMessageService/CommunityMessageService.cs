namespace Cobid.Api.Services.CommunityService.CommunityMessageService;

public class CommunityMessageService : ICommunityMessageService
{
    private readonly CobidDbContext _context;
    public CommunityMessageService(CobidDbContext context) => _context = context;
    public async Task<ServiceResponse<List<CommunityMessage>>> AddCommunityMessage(CommunityMessage communityMessage)
    {
        _context.CommunityMessages.Add(communityMessage);
        await _context.SaveChangesAsync();
        return await GetCommunityMessagesAsync();
    }

    public async Task<ServiceResponse<List<CommunityMessage>>> RemoveCommunityMessage(long communityMessageId)
    {
        CommunityMessage communityMessage = await GetCommunityMessageById(communityMessageId);
        if (communityMessage == null)
        {
            return new ServiceResponse<List<CommunityMessage>>
            {
                Success = false,
                Message = "Message not found"
            };
        }

        communityMessage.IsActive = false;
        await _context.SaveChangesAsync();
        return await GetCommunityMessagesAsync();
    }

    public async Task<CommunityMessage> GetCommunityMessageById(long communityMessageId)
    {
        return await _context.CommunityMessages.FirstOrDefaultAsync(x => x.CommunityMessageId == communityMessageId) ?? new();
    }
    public async Task<ServiceResponse<CommunityMessage>> GetCommunityMessageAsync(long communityMessageId)
    {
        var response = new ServiceResponse<CommunityMessage>();
        var communityMessage = await _context.CommunityMessages.FindAsync(communityMessageId);
        if (communityMessage == null)
        {
            response.Success = false;
            response.Message = "Message not found";
        }
        else
            response.Data = communityMessage;
        return response;
    }

    public async Task<ServiceResponse<List<CommunityMessage>>> GetCommunityMessagesAsync()
    {
        var response = new ServiceResponse<List<CommunityMessage>>
        { Data = await _context.CommunityMessages.Where(x => x.IsActive).ToListAsync() };
        return response;
    }

    public async Task<ServiceResponse<List<CommunityMessage>>> UpdateCommunityMessage(CommunityMessage communityMessage)
    {
        var dbCommunityMessage = await GetCommunityMessageById(communityMessage.CommunityMessageId);
        if (dbCommunityMessage == null)
        {
            return new ServiceResponse<List<CommunityMessage>>
            {
                Success = false,
                Message = "Message not found."
            };
        }

        dbCommunityMessage.CommunityPostId = communityMessage.CommunityPostId;
        dbCommunityMessage.SenderId = communityMessage.SenderId;
        dbCommunityMessage.MessageContent= communityMessage.MessageContent;
        dbCommunityMessage.Images = communityMessage.Images;
        dbCommunityMessage.FileAttachments= communityMessage.FileAttachments;
        dbCommunityMessage.IsRead = communityMessage.IsRead;
        dbCommunityMessage.IsActive = communityMessage.IsActive;
       

        await _context.SaveChangesAsync();
        return await GetCommunityMessagesAsync();
    }

    public async Task<ServiceResponse<List<CommunityMessage>>> GetCommunityMessagesByPostId(long communityPostId)
    {
        var response = new ServiceResponse<List<CommunityMessage>>
        { Data = await _context.CommunityMessages.Where(x => x.IsActive && x.CommunityPostId == communityPostId).ToListAsync() };
        return response;
    }
}
