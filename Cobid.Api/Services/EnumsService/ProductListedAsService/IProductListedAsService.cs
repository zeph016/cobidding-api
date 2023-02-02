namespace Cobid.Api.Services.EnumsService.ProductListedAsService
{
    public interface IProductListedAsService
    {
        Task<ServiceResponse<List<ProductListedAs>>> GetProductsListedAsAsync();
    }
}
