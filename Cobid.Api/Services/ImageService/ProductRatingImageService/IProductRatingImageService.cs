namespace Cobid.Api.Services.ImageService.ProductRatingImageService
{
    public interface IProductRatingImageService
    {
        Task<ServiceResponse<List<ProductRatingImage>>> GetProductRatingImagesAsync();
        Task<ServiceResponse<ProductRatingImage>> GetProudctRatingImageAsync(long producRatingImageId);   
        Task<ServiceResponse<List<ProductRatingImage>>> AddProductRatingImage(ProductRatingImage productRatingImage);
        Task<ServiceResponse<List<ProductRatingImage>>> UpdateProductRatingImage(ProductRatingImage productRatingImage);
        Task<ServiceResponse<List<ProductRatingImage>>> DeleteProductRatingImage(long productRatingImageId);
    }
}
