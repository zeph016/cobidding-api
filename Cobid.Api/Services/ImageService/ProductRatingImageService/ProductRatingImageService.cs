using Cobid.Api.Entities.Product;

namespace Cobid.Api.Services.ImageService.ProductRatingImageService
{
    public class ProductRatingImageService : IProductRatingImageService
    {
        private readonly CobidDbContext _context;
        public ProductRatingImageService(CobidDbContext context) => _context = context;
        
        public async Task<ServiceResponse<List<ProductRatingImage>>> AddProductRatingImage(ProductRatingImage productRatingImage)
        {
            _context.ProductRatingImages.Add(productRatingImage);
            await _context.SaveChangesAsync();
            return await GetProductRatingImagesAsync();
        }

        public async Task<ServiceResponse<List<ProductRatingImage>>> DeleteProductRatingImage(long productRatingImageId)
        {
            ProductRatingImage productRatingImage = await GetProductRatingImageById(productRatingImageId);
            if (productRatingImage == null)
            {
                return new ServiceResponse<List<ProductRatingImage>>
                {
                    Success = false,
                    Message = "Product rating image not found."
                };
            }
            productRatingImage.IsActive = false;
            await _context.SaveChangesAsync();
            return await GetProductRatingImagesAsync();
        }

        public async Task<ServiceResponse<ProductRatingImage>> GetProudctRatingImageAsync(long productRatingImageId)
        {
            var response = new ServiceResponse<ProductRatingImage>();
            var productRatingImage = await _context.ProductRatingImages.FindAsync(productRatingImageId);
            if (productRatingImage == null)
            {
                response.Success = false;
                response.Message = "Product rating image not found.";
            }
            else
                response.Data = productRatingImage;
            return response;
        }

        public async Task<ProductRatingImage> GetProductRatingImageById(long productRatingImageId)
        {
            return await _context.ProductRatingImages.FirstOrDefaultAsync(x => x.ProductRatingImageId == productRatingImageId) ?? new();
        }

        public async Task<ServiceResponse<List<ProductRatingImage>>> GetProductRatingImagesAsync()
        {
            var response = new ServiceResponse<List<ProductRatingImage>>
            { Data = await _context.ProductRatingImages.Where(x=>x.IsActive).ToListAsync() };
            return response;
        }

        public async Task<ServiceResponse<List<ProductRatingImage>>> UpdateProductRatingImage(ProductRatingImage productRatingImage)
        {
            var dbProductRatingImage = await GetProductRatingImageById(productRatingImage.ProductRatingImageId);
            if (dbProductRatingImage == null)
            {
                return new ServiceResponse<List<ProductRatingImage>>
                {
                    Success = false,
                    Message = "Product rating image not found."
                };
            }
            dbProductRatingImage.ProductRatingImageName = productRatingImage.ProductRatingImageName;
            dbProductRatingImage.ProductRatingImageLocation = productRatingImage.ProductRatingImageLocation;
            dbProductRatingImage.ProductRatingImageData = productRatingImage.ProductRatingImageData;

            await _context.SaveChangesAsync();
            return await GetProductRatingImagesAsync();
        }
    }
}
