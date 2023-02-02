namespace Cobid.Api.Services.ImageService.AuctionProductImageService
{
    public class AuctionProductImageService : IAuctionProductImageService
    {
        private readonly CobidDbContext _context;
        public AuctionProductImageService(CobidDbContext context) => _context = context;
        public async Task<ServiceResponse<List<AuctionProductImage>>> GetAuctionProductImageAsync()
        {
            var response = new ServiceResponse<List<AuctionProductImage>>
            { Data = await _context.AuctionProductImages.Where(x => x.IsActive).ToListAsync() };
            return response;
        }
        public async Task<ServiceResponse<List<AuctionProductImage>>> GetAuctionProductImageByAuctionId(long auctionId)
        {
            var response = new ServiceResponse<List<AuctionProductImage>>
            { Data = await _context.AuctionProductImages.Where(x => x.AuctionEventId == auctionId && x.IsActive).ToListAsync() };
            return response;
        }
    }
}
