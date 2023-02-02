namespace Cobid.Api.Services.CommunityService.CommunityPostService;

public interface ICommunityPostService
{
    Task<ServiceResponse<List<CommunityPost>>> GetCommunityPostsAsync();
    Task<ServiceResponse<CommunityPost>> GetCommunityPostAsync(long communityPostId);
    Task<ServiceResponse<List<CommunityPost>>> AddCommunityPost(CommunityPost communityPost);
    Task<ServiceResponse<List<CommunityPost>>> UpdateCommunityPost(CommunityPost communityPost);
    Task<ServiceResponse<List<CommunityPost>>> RemoveCommunityPost(long communityPostId);
}
