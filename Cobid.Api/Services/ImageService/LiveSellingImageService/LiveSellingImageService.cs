namespace Cobid.Api.Services.ImageService.LiveSellingImageService
{
    public class LiveSellingImageService : ILiveSellingImageService
    {
        private readonly CobidDbContext _context;
        public LiveSellingImageService(CobidDbContext context) => _context = context;

        public async Task<ServiceResponse<List<LiveSellingImage>>> AddLiveSellingImage(LiveSellingImage lsImage)
        {
            lsImage.IsEdit = lsImage.IsNew = false;
            _context.LiveSellingImages.Add(lsImage);
            await _context.SaveChangesAsync();
            return await GetLiveSellingImages();
        }

        public async Task<ServiceResponse<List<LiveSellingImage>>> DeleteLiveSellingImage(long lsImageId)
        {
            LiveSellingImage liveSellingImage = await GetLSImageById(lsImageId);
            if (liveSellingImage == null)
            {
                return new ServiceResponse<List<LiveSellingImage>>
                {
                    Success = false,
                    Message = "Image not found."
                };
            }

            //Disable user
            liveSellingImage.IsActive = false;
            await _context.SaveChangesAsync();
            return await GetLiveSellingImages();
        }

        private async Task<LiveSellingImage> GetLSImageById(long lsImageId)
        {
            return await _context.LiveSellingImages.FirstOrDefaultAsync(lsImg => lsImg.LiveSellingImageId == lsImageId);
        }

        public async Task<ServiceResponse<LiveSellingImage>> GetLiveSellingImage(long lsImageId)
        {
            var response = new ServiceResponse<LiveSellingImage>();
            var lsImage = await _context.LiveSellingImages.FindAsync(lsImageId);
            if (lsImage == null)
            {
                response.Success = false;
                response.Message = "Image not found";
            }
            else
                response.Data = lsImage;
            return response;
        }

        public async Task<ServiceResponse<List<LiveSellingImage>>> GetLiveSellingImages()
        {
            var response = new ServiceResponse<List<LiveSellingImage>>
            { Data = await _context.LiveSellingImages.ToListAsync() };
            return response;
        }

        public async Task<ServiceResponse<List<LiveSellingImage>>> GetLSImagesByLSId(long liveSellingId)
        {
            var response = new ServiceResponse<List<LiveSellingImage>>
            { Data = await _context.LiveSellingImages.Where(lsImg => lsImg.LiveSellingId == liveSellingId).ToListAsync() };
            return response;
        }

        public async Task<ServiceResponse<List<LiveSellingImage>>> UpdateLiveSellingImage(LiveSellingImage lsImage)
        {
            var dbLSImage = await GetLSImageById(lsImage.LiveSellingImageId);
            if (dbLSImage == null)
            {
                return new ServiceResponse<List<LiveSellingImage>>
                {
                    Success = false,
                    Message = "Image not found."
                };
            }

            dbLSImage.LiveSellingImageTitle = lsImage.LiveSellingImageTitle;
            dbLSImage.LiveSellingImageUrl = lsImage.LiveSellingImageUrl;
            dbLSImage.IsActive = lsImage.IsActive;

            await _context.SaveChangesAsync();
            return await GetLiveSellingImages();
        }
    }
}
