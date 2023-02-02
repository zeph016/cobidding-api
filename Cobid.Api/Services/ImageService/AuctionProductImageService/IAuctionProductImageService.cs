namespace Cobid.Api.Services.ImageService.AuctionProductImageService
{
    public interface IAuctionProductImageService
    {
        Task<ServiceResponse<List<AuctionProductImage>>> GetAuctionProductImageAsync();
        Task<ServiceResponse<List<AuctionProductImage>>> GetAuctionProductImageByAuctionId(long auctionId);
    }
}
