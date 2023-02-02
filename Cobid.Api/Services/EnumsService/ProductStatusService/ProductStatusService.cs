namespace Cobid.Api.Services.EnumsService.ProductStatusService
{
    public class ProductStatusService : IProductStatusService
    {
        private readonly CobidDbContext _context;
        public ProductStatusService(CobidDbContext context) => _context = context;
        public async Task<ServiceResponse<List<ProductStatus>>> GetProductStatusesAsync()
        {
            var response = new ServiceResponse<List<ProductStatus>>
            { Data = await _context.ProductStatuses.Where(x => x.IsActive).ToListAsync() };
            return response;
        }
    }
}
