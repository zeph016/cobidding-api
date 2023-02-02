using Cobid.Api.Services.RatingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductRatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        private readonly IProductService _productService;
        public ProductRatingController(IRatingService ratingService, IProductService productService)
        {
            _ratingService = ratingService;
            _productService = productService;
        }

            [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<ProductRating>>>> GetProductRatingsAsync()
        {
            var productRatings = await _ratingService.GetProductRatingsAsync();
            return Ok(productRatings);
        }
        [HttpGet("{productRatingId}")]
        public async Task<ActionResult<ServiceResponse<ProductRating>>> GetProductRatingById(long productRatingId)
        {
            var productRating = await _ratingService.GetProductRating(productRatingId);
            return Ok(productRating);
        }
        [HttpGet("ratings/productId={productId}")]
        public async Task<ActionResult<ServiceResponse<List<ProductRating>>>> GetProductRatingsByProdId(long productId)
        {
            var productRatings = await _ratingService.GetProductRatingsByProdId(productId);
            return Ok(productRatings);
        }
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<ProductRating>>>> AddProductRating(ProductRating productRating)
        {
            var result = await _ratingService.AddProductRating(productRating);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<ProductRating>>>> UpdateProductRating(ProductRating productRating)
        {
            var result = await _ratingService.UpdateProductRating(productRating);
            return Ok(result);
        }
        [HttpDelete("delete/{productRatingId}")]
        public async Task<ActionResult<ServiceResponse<List<ProductRating>>>> DeleteProductRating(long productRatingId)
        {
            var result = await _ratingService.DeleteProductRating(productRatingId);
            return Ok(result);
        }
        [HttpPut("disable/productratingid={productRatingId}")]
        public async Task<ActionResult<ServiceResponse<List<ProductRating>>>> DisableProductRating(long productRatingId)
        {
            var result = await _ratingService.DeleteProductRating(productRatingId);
            return Ok(result);
        }
        
    }
}
