using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductStatusController : ControllerBase
    {
        
        private readonly IProductStatusService _productStatusService;
        public ProductStatusController(IProductStatusService productStatusService) =>_productStatusService = productStatusService;

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<ProductStatus>>>> GetProductStatusesAsync()
        {
            var productStatuses = await _productStatusService.GetProductStatusesAsync();
            return Ok(productStatuses);
        }
    }
}
