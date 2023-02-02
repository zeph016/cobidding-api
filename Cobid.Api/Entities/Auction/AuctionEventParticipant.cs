using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.Auction;

public class AuctionEventParticipant
{
    public long AuctionEventParticipantId { get; set; }
    public long AuctionEventId { get; set; }
    public int UserId {  get; set; }
    public bool IsActive {  get; set; }
    public bool IsBanned { get; set; }  
}
