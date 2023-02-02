namespace Cobid.Api.Services.ImageService
{
    public interface IImageService
    {
        Task<ServiceResponse<List<UserValidationImage>>> GetValidationImages();
        Task<ServiceResponse<UserValidationImage>> GetValidationId(int imageId);
        Task<ServiceResponse<List<UserValidationImage>>> GetValidationIdsByUserId(int userId);
        Task<ServiceResponse<List<UserValidationImage>>> AddValidationId(UserValidationImage userValidationId);
        Task<ServiceResponse<List<UserValidationImage>>> AddValidationIds(List<UserValidationImage> images);
        Task<Int64> CountImagesByUserId(int userId);
    }
}
