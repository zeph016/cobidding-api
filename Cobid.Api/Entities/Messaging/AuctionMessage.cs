using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.Messaging;

public class AuctionMessage
{
    public long AuctionMessageId {  get; set; }
    public long AuctionEventId {  get; set; }
    public int SenderId { get; set; }
    public string MessageContent { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal AuctionBidAmt {  get; set; }
    public DateTime DateSent { get; set; }
    public bool IsRead { get; set; }
    public bool IsBidWinner { get; set; }
    public bool IsActive { get; set; }
    public bool IsBanned { get; set; }
}
