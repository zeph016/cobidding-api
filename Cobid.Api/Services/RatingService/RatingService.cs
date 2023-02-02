namespace Cobid.Api.Services.RatingService
{
    public class RatingService : IRatingService
    {
        private readonly CobidDbContext _context;
        public RatingService(CobidDbContext context) => _context = context;

        public async Task<ServiceResponse<List<ProductRating>>> AddProductRating(ProductRating productRating)
        {
            _context.ProductRatings.Add(productRating);
            await _context.SaveChangesAsync();
            return await GetProductRatingsAsync();
        }

        public async Task<ServiceResponse<List<ProductRating>>> DeleteProductRating(long productRatingId)
        {
            ProductRating productRating = await GetProductRatingById(productRatingId);
            if (productRating == null)
            {
                return new ServiceResponse<List<ProductRating>>
                { 
                    Success = false,
                    Message = "Product rating not found."
                };
            }
            //Disable rating
            productRating.isActive = false;
            await _context.SaveChangesAsync();
            return await GetProductRatingsAsync();
        }

        public async Task<ServiceResponse<ProductRating>> GetProductRating(long productRatingId)
        {
            var response = new ServiceResponse<ProductRating>();
            var productRating = await GetProductRatingById(productRatingId);
            if (productRating == null)
            {
                return new ServiceResponse<ProductRating>
                {
                    Success = false,
                    Message = "Product rating not found."
                };
            }
            else
                response.Data = productRating;
             return response;
        }

        public async Task<ServiceResponse<List<ProductRating>>> GetProductRatingsByProdId(long productId)
        {
            var response = new ServiceResponse<List<ProductRating>>
            {
                Data = await _context.ProductRatings.Include(x=>x.ProductRatingImages).Where(x=>x.ProductId== productId).ToListAsync()
            };
            return response;
        }
        public async Task<ProductRating> GetProductRatingById(long productRatingId)
        {
            return await _context.ProductRatings.FirstOrDefaultAsync(x => x.ProductRatingId == productRatingId) ?? new();
        }

        public async Task<ServiceResponse<List<ProductRating>>> GetProductRatingsAsync()
        {
            var response = new ServiceResponse<List<ProductRating>>
            { Data = await _context.ProductRatings.Where(x=>x.isActive).ToListAsync() };
            return response;
        }

        public async Task<ServiceResponse<List<ProductRating>>> UpdateProductRating(ProductRating productRating)
        {
            var dbProductRating = await GetProductRatingById(productRating.ProductRatingId);
            if (dbProductRating == null)
            {
                return new ServiceResponse<List<ProductRating>>
                {
                    Success = false,
                    Message = "Product rating not found."
                };
            }
            dbProductRating.ProductRatingDescription = productRating.ProductRatingDescription;
            dbProductRating.ProductRatingGrade = productRating.ProductRatingGrade;
            dbProductRating.ProductRatingComment = productRating.ProductRatingComment;
            dbProductRating.ProductRatingImages = productRating.ProductRatingImages;

            await _context.SaveChangesAsync();
            return await GetProductRatingsAsync();
        }
    }
}
