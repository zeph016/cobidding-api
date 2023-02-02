namespace Cobid.Api.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetUsersAsync();
        Task<ServiceResponse<User>> GetUserAsync(int userId);
        Task<ServiceResponse<List<User>>> AddUser(User user);
        Task<ServiceResponse<List<User>>> UpdateUser(User user);
        Task<ServiceResponse<List<User>>> DeleteUser(int userId);
    }
}
