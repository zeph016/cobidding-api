using System.Security.Cryptography.Xml;

namespace Cobid.Api.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly CobidDbContext _context;
        public ProductService(CobidDbContext context) => _context = context;

        public async Task<ServiceResponse<List<Product>>> AddProduct(Product product)
        {
            product.IsActive = true;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(long productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                response.Success = false;
                response.Message = "Product not found";
            }
            else
                response.Data = product;
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductWithImageAsync(long productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products.Include(x => x.ProductImages.Where(y=>y.IsActive)).FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                response.Success = false;
                response.Message = "Product not found";
            }
            else
                response.Data = product;
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsWithRatingsByUserId(int userId)
        {
            var response = new ServiceResponse<List<Product>>()
            { 
                Data = await _context.Products.Where(x=>x.UserId == userId).Include(y=>y.ProductRatings).ToListAsync()
            };
            return response;
        }
        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(int productCategoryId)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products.Where(x => x.ProductCategoryId == productCategoryId).Include(x=>x.ProductRatings).ToListAsync()
            };
            return response;
        }
        public async Task<ServiceResponse<List<Product>>> GetProductsByUser(int userId)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products.Where(x => x.UserId == userId).Include(x => x.ProductRatings).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            { Data = await _context.Products.ToListAsync() } ;
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> DeleteProduct(long productId)
        {
            Product product = await GetProductById(productId);
            if (product != null)
            {
                return new ServiceResponse<List<Product>>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }
            //Disable product
            if (product != null)
                product.IsActive = false;
            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }

        public async Task<Product> GetProductById(long productId)
        {
            return await _context.Products.FirstOrDefaultAsync(pId => pId.ProductId == productId) ?? new();
        }

        public async Task<ServiceResponse<List<Product>>> UpdateProduct(Product product)
        {
            var dbProduct = await GetProductById(product.ProductId);
            if (dbProduct == null)
            {
                return new ServiceResponse<List<Product>>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }
            dbProduct.ProductName = product.ProductName;
            dbProduct.ProductDescription = product.ProductDescription;
            dbProduct.ProductCategoryId = product.ProductCategoryId;
            dbProduct.ProductPrice = product.ProductPrice;
            dbProduct.ProductConditionId = product.ProductConditionId;
            dbProduct.Length = product.Length;
            dbProduct.Width = product.Width;
            dbProduct.Height = product.Height;
            dbProduct.DimensionModelId = product.DimensionModelId;
            dbProduct.Weight = product.Weight;
            dbProduct.WeightModelId = product.WeightModelId;
            dbProduct.ProductRanking = product.ProductRanking;
            dbProduct.ProductStatusId = product.ProductStatusId;
            dbProduct.ProductListedAs = product.ProductListedAs;
            dbProduct.ProductRating = product.ProductRating;
            dbProduct.ProductStockCount = product.ProductStockCount;
            dbProduct.ProductImages = product.ProductImages;
            dbProduct.IsActive = product.IsActive;

            await _context.SaveChangesAsync();
            return await GetProductsAsync();
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByUserId(int userId)
        {
            var response = new ServiceResponse<List<Product>>
            { Data = await _context.Products.Where(x => x.UserId == userId).ToListAsync() };
            return response;
        }

        public async Task<decimal> CountUserProductsTotalResponses(int userId)
        {
            decimal count = 0;
            var response = await _context.Products.Where(x => x.UserId == userId).Include(y => y.ProductRatings).ToListAsync();
            count = response.Sum(x => x.ProductRatings.Count());
            return count;
        }
        public async Task<decimal> CounterUserTotalRatingGrade(int userId)
        {
            decimal count = 0;
            var response = await _context.Products.Where(x => x.UserId == userId).Include(y => y.ProductRatings).ToListAsync();
            foreach (var list in response)
            {
                foreach(var item in list.ProductRatings)
                {
                    count = count + item.ProductRatingGrade;
                }
            }
            return count;
        }
    }
}
