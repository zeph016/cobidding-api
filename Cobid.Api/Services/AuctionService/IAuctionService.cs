

namespace Cobid.Api.Services.AuctionService
{
    public interface IAuctionService
    {
        Task<ServiceResponse<List<AuctionEvent>>> GetAuctionEventsAsync();
        Task<ServiceResponse<AuctionEvent>> GetAuctionEventsAsync(long auctionEventId);
        Task<ServiceResponse<List<AuctionEvent>>> AddAuctionEvent(AuctionEvent auctionEvent);
        Task<ServiceResponse<List<AuctionEvent>>> UpdateAuctionEvent(AuctionEvent auctionEvent);
        Task<ServiceResponse<List<AuctionEvent>>> DeleteAuctionEvent(long auctionEventId);
    }
}
