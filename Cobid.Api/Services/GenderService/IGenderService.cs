namespace Cobid.Api.Services.GenderService
{
    public interface IGenderService
    {
        Task<ServiceResponse<List<Gender>>> GetGendersAsync();
        Task<ServiceResponse<Gender>> GetGenderAsync(int genderId);
    }
}
