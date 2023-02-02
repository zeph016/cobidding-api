namespace Cobid.Api.Services.LiveSellingService
{
    public interface ILiveSellingService
    {
        Task<ServiceResponse<List<LiveSelling>>> GetLiveSellings();
        Task<ServiceResponse<LiveSelling>> GetLiveSelling(long liveSellingId);
        Task<ServiceResponse<List<LiveSelling>>> AddLiveSelling(LiveSelling liveSelling);
        Task<ServiceResponse<List<LiveSelling>>> UpdateLiveSelling(LiveSelling liveSelling);
        Task<ServiceResponse<List<LiveSelling>>> DeleteLiveSelling(long liveSellingId);
    }
}
