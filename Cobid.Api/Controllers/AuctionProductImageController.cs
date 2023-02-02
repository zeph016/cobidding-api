using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionProductImageController : ControllerBase
    {
        private readonly IAuctionProductImageService _auctionProductImageService;
        public AuctionProductImageController(IAuctionProductImageService auctionProductImageService) => _auctionProductImageService = auctionProductImageService;

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<AuctionProductImage>>>> GetAuctionProductImageAsync()
        {
            var auctionProductImages = await _auctionProductImageService.GetAuctionProductImageAsync();
            return Ok(auctionProductImages);
        }
        [HttpGet("all/auctionId={auctionId}")]
        public async Task<ActionResult<ServiceResponse<List<ProductImage>>>> GetAuctionProductImageByAuctionId(long auctionId)
        {
            var auctionProductImages = await _auctionProductImageService.GetAuctionProductImageByAuctionId(auctionId);
            return Ok(auctionProductImages);
        }
    }
}
