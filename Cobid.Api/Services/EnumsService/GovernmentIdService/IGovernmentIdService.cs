namespace Cobid.Api.Services.EnumsService.GovernmentIdService
{
    public interface IGovernmentIdService
    {
        Task<ServiceResponse<List<GovernmentIdentification>>> GetAllGovIdTypes();
    }
}
