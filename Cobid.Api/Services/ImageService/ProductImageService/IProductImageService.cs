namespace Cobid.Api.Services.ImageService.ProductImageService
{
    public interface IProductImageService
    {
        Task<ServiceResponse<ProductImage>> GetProductImage (long productId);
        Task<ServiceResponse<List<ProductImage>>> GetProductImages();
        Task<ServiceResponse<List<ProductImage>>> GetProductImagesByProdId(long productId);
        Task<ServiceResponse<List<ProductImage>>> DisableProductImage (long productId);
    }
}
