namespace Cobid.Api.Services.MessagingServices.AuctionMessageService;

public interface IAuctionMessageService
{
    Task<ServiceResponse<List<AuctionMessage>>> GetAuctionMessagesAsync();
    Task<ServiceResponse<AuctionMessage>> GetAuctionMessageAsync(long auctionMessageId);
    Task<ServiceResponse<List<AuctionMessage>>> AddAuctionMessage(AuctionMessage auctionMessage);
    Task<ServiceResponse<List<AuctionMessage>>> UpdateAuctionMessage(AuctionMessage auctionMessage);
    Task<ServiceResponse<List<AuctionMessage>>> RemoveAuctionMessage(long auctionMessageId);
    Task<ServiceResponse<AuctionMessage>> GetLastAuctionEventMessage(long auctionEventId);
    Task<decimal> GetHighestBidCalc(long auctionEventId);
}
