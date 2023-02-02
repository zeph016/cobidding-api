

namespace Cobid.Api.Services.MessagingServices.AuctionMessageService;

public class AuctionMessageService : IAuctionMessageService
{
    private readonly CobidDbContext _context;
    public AuctionMessageService(CobidDbContext context) => _context = context;
    public async Task<ServiceResponse<List<AuctionMessage>>> AddAuctionMessage(AuctionMessage auctionMessage)
    {
        _context.AuctionMessages.Add(auctionMessage);
        await _context.SaveChangesAsync();
        return await GetAuctionMessagesAsync();
    }

    public async Task<ServiceResponse<List<AuctionMessage>>> RemoveAuctionMessage(long auctionMessageId)
    {
        AuctionMessage auctionMessage = await GetAuctionMessageById(auctionMessageId);
        if (auctionMessage == null)
        {
            return new ServiceResponse<List<AuctionMessage>>
            {
                Success = false,
                Message = "Message not found"
            };
        }

        auctionMessage.IsActive = false;
        await _context.SaveChangesAsync();
        return await GetAuctionMessagesAsync();
    }

    public async Task<AuctionMessage> GetAuctionMessageById(long auctionMessagId)
    {
        return await _context.AuctionMessages.FirstOrDefaultAsync(x => x.AuctionMessageId == auctionMessagId) ?? new();
    }

    public async Task<ServiceResponse<AuctionMessage>> GetAuctionMessageAsync(long auctionMessageId)
    {
        var response = new ServiceResponse<AuctionMessage>();
        var auctionMessage = await _context.AuctionMessages.FindAsync(auctionMessageId);
        if (auctionMessage == null)
        {
            response.Success = false;
            response.Message = "Message not found";
        }
        else
            response.Data = auctionMessage;
        return response;
    }
    public async Task<ServiceResponse<List<AuctionMessage>>> GetAuctionMessagesAsync()
    {
        var response = new ServiceResponse<List<AuctionMessage>>
        { Data = await _context.AuctionMessages.Where(x=>x.IsActive).ToListAsync() };
        return response;
    }

    public async Task<ServiceResponse<List<AuctionMessage>>> UpdateAuctionMessage(AuctionMessage auctionMessage)
    {
        var dbMessage = await GetAuctionMessageById(auctionMessage.AuctionMessageId);
        if (dbMessage == null)
        {
            return new ServiceResponse<List<AuctionMessage>>
            {
                Success = false,
                Message = "Message not found."
            };
        }

        dbMessage.AuctionEventId = auctionMessage.AuctionEventId;
        dbMessage.SenderId = auctionMessage.SenderId;
        dbMessage.MessageContent = auctionMessage.MessageContent;
        dbMessage.AuctionBidAmt = auctionMessage.AuctionBidAmt;
        dbMessage.DateSent = auctionMessage.DateSent;
        dbMessage.IsRead = auctionMessage.IsRead;
        dbMessage.IsBidWinner = auctionMessage.IsBidWinner;
        dbMessage.IsActive = auctionMessage.IsActive;
        dbMessage.IsBanned = auctionMessage.IsBanned;

        await _context.SaveChangesAsync();
        return await GetAuctionMessagesAsync();
    }

    public async Task<ServiceResponse<AuctionMessage>> GetLastAuctionEventMessage(long auctionEventId)
    {
        var response = new ServiceResponse<AuctionMessage>();
        var message = await _context.AuctionMessages.Where(x => x.AuctionEventId == auctionEventId).OrderByDescending(x => x.AuctionMessageId).FirstOrDefaultAsync();
        if (message == null)
        {
            response.Success = false;
            response.Message = "Message not found";
        }
        else
            response.Data = message;
        return response;
    }

    public async Task<decimal> GetHighestBidCalc(long auctionEventId)
    {
        var auctionMessages = await _context.AuctionMessages.Where(x => x.AuctionEventId == auctionEventId).ToListAsync();
        decimal highestBid = 0;
        if (auctionMessages.Count() != 0) 
        {
            highestBid = auctionMessages.Max(x => x.AuctionBidAmt);
        }
        return highestBid;
    }
}
