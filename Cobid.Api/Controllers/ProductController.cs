using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(long productId)
        {
            var product = await _productService.GetProductAsync(productId);
            return Ok(product);
        }
        [HttpGet("view/{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductWithImage(long productId)
        {
            var product = await _productService.GetProductWithImageAsync(productId);
            return Ok(product);
        }
        [HttpDelete("delete/{id}"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> DeleteProduct(int productId)
        {
            var result = await _productService.DeleteProduct(productId);
            return Ok(result);
        }

        [HttpPost("add"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> AddProduct(Product product)
        {
            var result = await _productService.AddProduct(product);
            return Ok(result);
        }
        [HttpPut("update"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> UpdateProduct(Product product)
        {
            var result = await _productService.UpdateProduct(product);
            return Ok(result);
        }
        [HttpGet("list/user/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByUserId(int userId)
        {
            var products = await _productService.GetProductsByUserId(userId);
            return Ok(products);
        }
        [HttpGet("all/responses/{userId}")]
        public async Task<ActionResult<decimal>> CountUserProductsTotalResponses(int userId)
        {
            var result = await _productService.CountUserProductsTotalResponses(userId);
            return Ok(result);
        }
        [HttpGet("all/grade/{userId}")]
        public async Task<ActionResult<decimal>> CounterUserTotalRatingGrade(int userId)
        {
            var result = await _productService.CounterUserTotalRatingGrade(userId);
            return Ok(result);
        }
        [HttpGet("list/all/user/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsWithRatingsByUserId(int userId)
        {
            var products = await _productService.GetProductsWithRatingsByUserId(userId);
            return Ok(products);
        }
        [HttpGet("all/category={productCategoryId}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(int productCategoryId)
        {
            var products = await _productService.GetProductsByCategory(productCategoryId);
            return Ok(products);
        }
        [HttpGet("all/user={userId}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByUser(int userId)
        {
            var products = await _productService.GetProductsByUser(userId);
            return Ok(products);
        }
    }
}
