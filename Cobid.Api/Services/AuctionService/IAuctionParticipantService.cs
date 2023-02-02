namespace Cobid.Api.Services.AuctionService;

public interface IAuctionParticipantService
{
    Task<ServiceResponse<List<AuctionEventParticipant>>> GetAllParticipantsAsync();
    Task<ServiceResponse<AuctionEventParticipant>> GetAuctionEventParticipant(long auctionEventParticipantId);
    Task<ServiceResponse<AuctionEventParticipant>> GetAuctionEventParticipantByUserId(long auctionEventId, int userId);
    Task<ServiceResponse<List<AuctionEventParticipant>>> AddAuctionEventParticipant(AuctionEventParticipant auctionEventParticipant);
    Task<ServiceResponse<List<AuctionEventParticipant>>> UpdateAuctionEventParticipant(AuctionEventParticipant auctionEventParticipant);
    Task<ServiceResponse<List<AuctionEventParticipant>>> RemoveAuctionEventParticipant(AuctionEventParticipant auctionEventParticipant);
    Task<int> CountParticipantsByAuctionId(long auctionEventId);

}
