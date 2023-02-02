namespace Cobid.Api.Entities.Auction

{
    public class AuctionProductImage
    {
        public long AuctionProductImageId { get; set; }
        public long AuctionEventId { get; set; }
        public string AuctionProductImageTitle { get; set; } = string.Empty;
        public string AuctionProductImageUrl { get; set; } = string.Empty;
        public string AuctionProductImageData { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
