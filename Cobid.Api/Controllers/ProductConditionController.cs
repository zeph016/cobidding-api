using Microsoft.AspNetCore.Mvc;

namespace Cobid.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductConditionController : ControllerBase
    {
        private readonly IProductConditionService _productConditionService;
        public ProductConditionController(IProductConditionService productConditionService) =>_productConditionService = productConditionService;

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<ProductCondition>>>> GetProductConditionsAsync()
        {
            var productConditions = await _productConditionService.GetProductConditionsAsync();
            return Ok(productConditions);
        }
    }
}
