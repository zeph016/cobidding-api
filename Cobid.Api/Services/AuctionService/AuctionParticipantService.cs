using Cobid.Api.Entities.Auction;

namespace Cobid.Api.Services.AuctionService;

public class AuctionParticipantService : IAuctionParticipantService
{
    private readonly CobidDbContext _context;
    public AuctionParticipantService(CobidDbContext context) => _context = context;
    public async Task<ServiceResponse<List<AuctionEventParticipant>>> AddAuctionEventParticipant(AuctionEventParticipant auctionEventParticipant)
    {
        _context.AuctionEventParticipants.Add(auctionEventParticipant);
        await _context.SaveChangesAsync();
        return await GetAllParticipantsAsync();
    }

    public async Task<ServiceResponse<List<AuctionEventParticipant>>> RemoveAuctionEventParticipant(AuctionEventParticipant _auctionEventParticipant)
    {
        AuctionEventParticipant auctionEventParticipant = await GetAuctionEventParticipantById(_auctionEventParticipant.AuctionEventParticipantId);
        if (auctionEventParticipant == null)
        {
            return new ServiceResponse<List<AuctionEventParticipant>> 
            {
                Success = false,
                Message = "Participant not found."
            };
        }
        auctionEventParticipant.IsActive = false;
        await _context.SaveChangesAsync();
        return await GetAllParticipantsAsync();
    }

    public async Task<AuctionEventParticipant> GetAuctionEventParticipantById(long auctionEventParticipantId)
    {
        return await _context.AuctionEventParticipants.FirstOrDefaultAsync(x => x.AuctionEventParticipantId == auctionEventParticipantId) ?? new();
    }

    public async Task<ServiceResponse<AuctionEventParticipant>> GetAuctionEventParticipant(long auctionEventParticipantId)
    {
        var response = new ServiceResponse<AuctionEventParticipant>();
        var auctionEventParticipant = await _context.AuctionEventParticipants.FindAsync(auctionEventParticipantId);
        if (auctionEventParticipant == null)
        {
            response.Success = false;
            response.Message = "Participant not found.";
        }
        else
            response.Data = auctionEventParticipant;
        return response;
    }

    public async Task<ServiceResponse<AuctionEventParticipant>> GetAuctionEventParticipantByUserId(long auctionEventId, int userId)
    {
        var response = new ServiceResponse<AuctionEventParticipant>();
        var auctionEventParticipant = await _context.AuctionEventParticipants.Where(x=>x.AuctionEventId == auctionEventId && x.UserId == userId).FirstOrDefaultAsync();
        if (auctionEventParticipant == null)
        {
            response.Success = false;
            response.Message = "Participant not found.";
        }
        else
            response.Data = auctionEventParticipant;
        return response;
    }

    public async Task<ServiceResponse<List<AuctionEventParticipant>>> GetAllParticipantsAsync()
    {
        var response = new ServiceResponse<List<AuctionEventParticipant>>
        { Data = await _context.AuctionEventParticipants.ToListAsync() };
        return response;
    }

    public async Task<ServiceResponse<List<AuctionEventParticipant>>> UpdateAuctionEventParticipant(AuctionEventParticipant auctionEventParticipant)
    {
        var dbParticipant = await GetAuctionEventParticipantById(auctionEventParticipant.AuctionEventParticipantId); 
        if (dbParticipant == null) 
        {
            return new ServiceResponse<List<AuctionEventParticipant>>
            {
                Success = false,
                Message = "Participant not found."
            };
        }

        dbParticipant.AuctionEventId = auctionEventParticipant.AuctionEventId;
        dbParticipant.UserId = auctionEventParticipant.UserId;
        dbParticipant.IsActive = auctionEventParticipant.IsActive;
        dbParticipant.IsBanned = auctionEventParticipant.IsBanned;

        await _context.SaveChangesAsync();
        return await GetAllParticipantsAsync();
    }

    public async Task<int> CountParticipantsByAuctionId(long auctionEventId)
    {
        int count = 0;
        var response = await _context.AuctionEventParticipants.Where(x => x.AuctionEventId == auctionEventId && x.IsActive).ToListAsync();
        count = response.Count();
        return count;
    }
}
