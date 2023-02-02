using Cobid.Api.Entities.Product;

namespace Cobid.Api.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(long productId);
        Task<ServiceResponse<Product>> GetProductWithImageAsync(long productId);
        Task<ServiceResponse<List<Product>>> GetProductsWithRatingsByUserId(int userId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(int productCategoryId);
        Task<ServiceResponse<List<Product>>> GetProductsByUser(int userId);
        Task<decimal> CountUserProductsTotalResponses(int userId);
        Task<decimal> CounterUserTotalRatingGrade(int userId);
        Task<ServiceResponse<List<Product>>> AddProduct(Product product);
        Task<ServiceResponse<List<Product>>> UpdateProduct(Product product);
        Task<ServiceResponse<List<Product>>> DeleteProduct(long productId);
        Task<ServiceResponse<List<Product>>> GetProductsByUserId (int userId);
    }
}
