using Microsoft.EntityFrameworkCore;

namespace Cobid.Api.Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly CobidDbContext _context;
        public ImageService(CobidDbContext context) => _context = context;
        public async Task<ServiceResponse<List<UserValidationImage>>> GetValidationImages()
        {
            var response = new ServiceResponse<List<UserValidationImage>>
            { Data = await _context.UserValidationImages.Where(x => x.IsActive).ToListAsync() };
            return response;
        }
        public async Task<ServiceResponse<List<UserValidationImage>>> GetValidationIdsByUserId(int userId)
        {
            var response = new ServiceResponse<List<UserValidationImage>>
            { Data = await _context.UserValidationImages.Where(x => x.UserId == userId && x.IsActive == true).ToListAsync() };
            return response;
        }

        public async Task<UserValidationImage> GetValidationImageById(int imageId)
        {
            return await _context.UserValidationImages.FirstOrDefaultAsync(xId => xId.Id == imageId) ?? new();
        }

        public async Task<ServiceResponse<List<UserValidationImage>>> AddValidationId(UserValidationImage userValidationId)
        {
            _context.UserValidationImages.Add(userValidationId);
            await _context.SaveChangesAsync();
            return await GetValidationIdsByUserId(userValidationId.UserId);
        }
        public async Task<ServiceResponse<List<UserValidationImage>>> AddValidationIds(List<UserValidationImage> images)
        {
            foreach (var item in images)
            {
                _context.UserValidationImages.Add(item);
                await _context.SaveChangesAsync();
            }
            return await GetValidationImages();
        }

        public async Task<ServiceResponse<UserValidationImage>> GetValidationId(int imageId)
        {
            var response = new ServiceResponse<UserValidationImage>();
            var image = await _context.UserValidationImages.FindAsync(imageId);
            if (image == null)
            {
                response.Success = false;
                response.Message = "Image not found";
            }
            else
                response.Data = image;
            return response;
        }

        public async Task<Int64> CountImagesByUserId(int userId)
        {
            return await _context.UserValidationImages.CountAsync(x => x.UserId == userId);
        }
    }
}
