using Cobid.Api.Entities.Auction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.Auction
{
    public class AuctionEvent
    {
        public long AuctionEventId {  get; set; }
        public int UserId { get; set; }
        public string AuctionEventTitle { get; set; } = string.Empty;
        public string AuctionEventDescription { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal AuctionEventStartingBid { get; set; }
        public DateTime AuctionEventDateStart { get; set; }
        public DateTime AuctionEventDateEnd { get; set; }
        public int ProductConditionId { get; set; }
        public List<AuctionProductImage> AuctionProductImages { get; set; } = new List<AuctionProductImage>();
        public List<AuctionEventParticipant> AuctiontParticipants { get; set; } = new List<AuctionEventParticipant>();
        public List<AuctionMessage> AuctionMessages { get; set; } = new List<AuctionMessage>();
        public bool IsActive { get; set; }
        public bool HasStarted { get; set; }
        public bool HasEnded { get; set; }
        public bool Deleted { get; set; }
    }
}
