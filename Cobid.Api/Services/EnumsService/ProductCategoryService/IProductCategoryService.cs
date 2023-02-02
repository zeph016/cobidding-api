namespace Cobid.Api.Services.EnumsService.ProductCategoryService
{
    public interface IProductCategoryService
    {
        Task<ServiceResponse<List<ProductCategory>>> GetProductCategoriesAsync();
    }
}
