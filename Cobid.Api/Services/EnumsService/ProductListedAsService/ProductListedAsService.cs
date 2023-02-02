namespace Cobid.Api.Services.EnumsService.ProductListedAsService
{
    public class ProductListedAsService : IProductListedAsService
    {
        public readonly CobidDbContext _context;
        public ProductListedAsService(CobidDbContext context) => _context = context;

        public async Task<ServiceResponse<List<ProductListedAs>>> GetProductsListedAsAsync()
        {
            var response = new ServiceResponse<List<ProductListedAs>>
            { Data = await _context.ProductsListedAs.Where(x => x.IsActive).ToListAsync() };
            return response;
        }
    }
}
