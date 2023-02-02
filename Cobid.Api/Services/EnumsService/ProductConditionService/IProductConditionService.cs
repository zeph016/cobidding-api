namespace Cobid.Api.Services.EnumsService.ProductConditionService
{
    public interface IProductConditionService
    {
        Task<ServiceResponse<List<ProductCondition>>> GetProductConditionsAsync();
    }
}
