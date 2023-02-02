using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductRatingImageController : ControllerBase
    {
        private readonly IProductRatingImageService _productRatingImageService;
        public ProductRatingImageController(IProductRatingImageService productRatingImageService) => _productRatingImageService = productRatingImageService;

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductRatingImage>>>> GetProductRatingImagesAsync()
        {
            var producRatingImages = await _productRatingImageService.GetProductRatingImagesAsync();
            return Ok(producRatingImages);
        }
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<ProductRatingImageService>>>> AddProductRatingImage(ProductRatingImage productRatingImage)
        {
            var result = await _productRatingImageService.AddProductRatingImage(productRatingImage);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<ProductRatingImage>>>> UpdateProductRatingImage(ProductRatingImage productRatingImage)
        {
            var result = await _productRatingImageService.UpdateProductRatingImage(productRatingImage);
            return Ok(result);
        }
        [HttpDelete("delete/{productRatingImageId}")]
        public async Task<ActionResult<ServiceResponse<List<ProductRatingImage>>>> DeleteProductRatingImage(long productRatingImageId)
        {
            var result = await _productRatingImageService.DeleteProductRatingImage(productRatingImageId);
            return Ok(result);
        }
        [HttpPut("delete/productratingimageid={productRatingImageId}")]
        public async Task<ActionResult<ServiceResponse<List<ProductRatingImage>>>> DisableProductRatingImage(long productRatingImageId)
        {
            var result = await _productRatingImageService.DeleteProductRatingImage(productRatingImageId);
            return Ok(result);
        }
    }
}
