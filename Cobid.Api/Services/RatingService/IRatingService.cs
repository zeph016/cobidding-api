namespace Cobid.Api.Services.RatingService
{
    public interface IRatingService
    {
        Task<ServiceResponse<List<ProductRating>>> GetProductRatingsAsync();
        Task<ServiceResponse<ProductRating>> GetProductRating(long productRatingId);
        Task<ServiceResponse<List<ProductRating>>> GetProductRatingsByProdId(long productId);
        Task<ServiceResponse<List<ProductRating>>> AddProductRating(ProductRating productRating);
        Task<ServiceResponse<List<ProductRating>>> UpdateProductRating(ProductRating productRating);
        Task<ServiceResponse<List<ProductRating>>> DeleteProductRating(long productId);
    }
}
