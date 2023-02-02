namespace Cobid.Api.Services.EnumsService.ProductCategoryService
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly CobidDbContext _context;
        public ProductCategoryService(CobidDbContext context) => _context = context;
        public async Task<ServiceResponse<List<ProductCategory>>> GetProductCategoriesAsync()
        {
            var response = new ServiceResponse<List<ProductCategory>>
            { Data = await _context.ProductCategories.Where(x => x.IsActive).ToListAsync() };
            return response;
        }
    }
}
