
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace Cobid.Api.Services.AuctionService
{
    public class AuctionService : IAuctionService
    {
        private readonly CobidDbContext _context;
        public AuctionService(CobidDbContext context) => _context = context;
        public async Task<ServiceResponse<List<AuctionEvent>>> AddAuctionEvent(AuctionEvent auctionEvent)
        {
            _context.AuctionEvents.Add(auctionEvent);
            await _context.SaveChangesAsync();
            return await GetAuctionEventsAsync();
        }

        public async Task<ServiceResponse<List<AuctionEvent>>> DeleteAuctionEvent(long auctionEventId)
        {
            AuctionEvent auctionEvent = await GetAuctionEventById(auctionEventId);
            if (auctionEvent == null)
            {
                return new ServiceResponse<List<AuctionEvent>>
                {
                    Success = false,
                    Message = "Auction event not found."
                };
            }

            //Disable Auction event
            auctionEvent.IsActive = false;
            await _context.SaveChangesAsync();
            return await GetAuctionEventsAsync();
        }

        public async Task<AuctionEvent> GetAuctionEventById(long auctionEventId)
        {
            return await _context.AuctionEvents.FirstOrDefaultAsync(aId => aId.AuctionEventId == auctionEventId) ?? new();
        }
        public async Task<ServiceResponse<AuctionEvent>> GetAuctionEventsAsync(long auctionEventId)
        {
            var response = new ServiceResponse<AuctionEvent>();
            var auctionEvent = await _context.AuctionEvents.Include(x => x.AuctionProductImages).Include(x => x.AuctionMessages).FirstOrDefaultAsync(x=> x.AuctionEventId == auctionEventId);
            if (auctionEvent == null)
            {
                response.Success = false;
                response.Message = "Auction event not found";
            }
            else
                response.Data = auctionEvent;
            //response.Data = await _context.AuctionEvents.Include(x => x.AuctionProductImages.Where(y => y.AuctionEventId == auctionEvent.AuctionEventId)).FirstOrDefaultAsync(x => x.AuctionEventId == auctionEvent.AuctionEventId);
            return response;
        }
        public async Task<ServiceResponse<List<AuctionEvent>>> GetAuctionEventsAsync()
        {
            var response = new ServiceResponse<List<AuctionEvent>>
            { Data = await _context.AuctionEvents.Where(x => x.IsActive).ToListAsync() };
            return response;
        }
        public async Task<ServiceResponse<List<AuctionEvent>>> UpdateAuctionEvent(AuctionEvent auctionEvent)
        {
            var dbAuctionEvent = await GetAuctionEventById(auctionEvent.AuctionEventId);
            if (dbAuctionEvent == null)
            {
                return new ServiceResponse<List<AuctionEvent>>
                {
                    Success = false,
                    Message = "Auction event not found."
                };
            }

            dbAuctionEvent.UserId = auctionEvent.UserId;
            dbAuctionEvent.AuctionEventTitle = auctionEvent.AuctionEventTitle;
            dbAuctionEvent.AuctionEventDescription = auctionEvent.AuctionEventDescription;
            dbAuctionEvent.AuctionEventStartingBid = auctionEvent.AuctionEventStartingBid;
            dbAuctionEvent.AuctionEventDateStart = auctionEvent.AuctionEventDateStart;
            dbAuctionEvent.AuctionEventDateEnd = auctionEvent.AuctionEventDateEnd;
            dbAuctionEvent.ProductConditionId = auctionEvent.ProductConditionId;
            dbAuctionEvent.AuctionProductImages = auctionEvent.AuctionProductImages;
            dbAuctionEvent.AuctiontParticipants = auctionEvent.AuctiontParticipants;
            dbAuctionEvent.AuctionMessages = auctionEvent.AuctionMessages;
            dbAuctionEvent.IsActive = auctionEvent.IsActive;
            dbAuctionEvent.HasStarted = auctionEvent.HasStarted;
            dbAuctionEvent.HasEnded = auctionEvent.HasEnded;
            dbAuctionEvent.Deleted = auctionEvent.Deleted;

            await _context.SaveChangesAsync();
            return await GetAuctionEventsAsync();
        }
    }
}
