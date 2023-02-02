using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService) => _productImageService = productImageService;
        
        [HttpGet("productid={productId}")]
        public async Task<ActionResult<ServiceResponse<ProductImage>>> GetProduct(long productId)
        {
            var product = await _productImageService.GetProductImage(productId);
            return Ok(product);
        }
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<ProductImage>>>> GetProductImages()
        {
            var productImages = await _productImageService.GetProductImages();
            return Ok(productImages);
        }
        [HttpGet("all/productid={productId}")]
        public async Task<ActionResult<ServiceResponse<List<ProductImage>>>> GetProductImagesByProdId(long productId)
        {
            var productImages = await _productImageService.GetProductImagesByProdId(productId);
            return Ok(productImages);
        }
        [HttpPut("disable/product={productImageId}"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<ProductImage>>>> DisableImage(long productImageId)
        {
            var result = await _productImageService.DisableProductImage(productImageId);
            return Ok(result);
        }
    }
}
