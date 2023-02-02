namespace Cobid.Api.Services.ImageService.ProductImageService
{
    public class ProductImageService : IProductImageService
    {
        private readonly CobidDbContext _context;
        public ProductImageService(CobidDbContext context) => _context = context;
        public async Task<ServiceResponse<ProductImage>> GetProductImage(long productId)
        {
            var response = new ServiceResponse<ProductImage>();
            var productImage = await _context.ProductImages.Where(x=>x.ProductId == productId && x.IsActive == true).FirstOrDefaultAsync();
            if (productImage == null)
            {
                response.Success = false;
                response.Message = "Product image not found";
            }
            else
                response.Data = productImage;
            return response;
        }
        public async Task<ServiceResponse<List<ProductImage>>> GetProductImages()
        {
            var response = new ServiceResponse<List<ProductImage>>
            { Data = await _context.ProductImages.Where(x => x.IsActive).ToListAsync() };
            return response;
        }
        public async Task<ServiceResponse<List<ProductImage>>> GetProductImagesByProdId(long productId)
        {
            var response = new ServiceResponse<List<ProductImage>>
            { Data = await _context.ProductImages.Where(x=>x.ProductId == productId && x.IsActive).ToListAsync() };
            return response;
        }

        public async Task<ProductImage> GetSingleImageById(long productImageId)
        {
            var result = await _context.ProductImages.FirstOrDefaultAsync(x=>x.ProductImageId == productImageId);
            if (result != null)
                return result;
            else
                return new();
        }

        public async Task<ServiceResponse<List<ProductImage>>> DisableProductImage(long productImageId)
        {
            var dbProductImage = await GetSingleImageById(productImageId);
            if (dbProductImage == null)
            {
                return new ServiceResponse<List<ProductImage>>
                {
                    Success = false,
                    Message = "Product image not found."
                };
            }

            dbProductImage.IsActive = false;
            await _context.SaveChangesAsync();
            return await GetProductImages();
        }
    }
}
