using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService) => _productCategoryService = productCategoryService;

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<ProductCategory>>>> GetProductCategoriesAsync()
        {
            var productCategories = await _productCategoryService.GetProductCategoriesAsync();
            return Ok(productCategories);
        }
    }
}
