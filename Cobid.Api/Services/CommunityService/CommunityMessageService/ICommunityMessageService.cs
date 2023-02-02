namespace Cobid.Api.Services.CommunityService.CommunityMessageService;

public interface ICommunityMessageService
{
    Task<ServiceResponse<List<CommunityMessage>>> GetCommunityMessagesAsync();
    Task<ServiceResponse<CommunityMessage>> GetCommunityMessageAsync(long communityMessageId);
    Task<ServiceResponse<List<CommunityMessage>>> AddCommunityMessage(CommunityMessage communityMessage);
    Task<ServiceResponse<List<CommunityMessage>>> UpdateCommunityMessage(CommunityMessage communityMessage);
    Task<ServiceResponse<List<CommunityMessage>>> RemoveCommunityMessage(long communityMessageId);
    Task<ServiceResponse<List<CommunityMessage>>> GetCommunityMessagesByPostId(long communityPostId);
}
