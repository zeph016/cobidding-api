namespace Cobid.Api.Services.EnumsService.ProductConditionService
{
    public class ProductConditionService : IProductConditionService
    {
        private readonly CobidDbContext _context;
        public ProductConditionService(CobidDbContext context) => _context = context;

        public async Task<ServiceResponse<List<ProductCondition>>> GetProductConditionsAsync()
        {
            var response = new ServiceResponse<List<ProductCondition>>
            { Data = await _context.ProductConditions.Where(x => x.IsActive).ToListAsync() };
            return response;
        }
    }
}
