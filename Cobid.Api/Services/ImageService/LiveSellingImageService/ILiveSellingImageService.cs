namespace Cobid.Api.Services.ImageService.LiveSellingImageService
{
    public interface ILiveSellingImageService
    {
        Task<ServiceResponse<List<LiveSellingImage>>> GetLiveSellingImages();
        Task<ServiceResponse<List<LiveSellingImage>>> GetLSImagesByLSId(long liveSellingId);
        Task<ServiceResponse<LiveSellingImage>> GetLiveSellingImage(long lsImageId);
        Task<ServiceResponse<List<LiveSellingImage>>> AddLiveSellingImage(LiveSellingImage lsImage);
        Task<ServiceResponse<List<LiveSellingImage>>> UpdateLiveSellingImage(LiveSellingImage lsImage);
        Task<ServiceResponse<List<LiveSellingImage>>> DeleteLiveSellingImage(long lsImageId);
    }
}
