namespace Cobid.Api.Services.EnumsService.ProductStatusService
{
    public interface IProductStatusService
    {
        Task<ServiceResponse<List<ProductStatus>>> GetProductStatusesAsync();
    }
}
