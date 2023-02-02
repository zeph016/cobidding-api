namespace Cobid.Api.Services.UserTypeService
{
    public interface IUserTypeService
    {
        Task<ServiceResponse<List<UserType>>> GetUserTypesAsync();
        Task<ServiceResponse<UserType>> GetUserTypeAsync(int userTypeId);
    }
}
