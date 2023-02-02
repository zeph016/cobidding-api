using Cobid.Api.Services.EnumsService.ProductListedAsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductListedAsController : ControllerBase
    {
        private readonly IProductListedAsService _productListedAsService;
        public ProductListedAsController(IProductListedAsService productListedAsService) => _productListedAsService = productListedAsService;

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<ProductListedAs>>>> GetProductsListedAs()
        {
            var productsListedAs = await _productListedAsService.GetProductsListedAsAsync();
            return Ok(productsListedAs);
        }
    }
}
