using Cobid.Api.Entities.Community;

namespace Cobid.Api.Services.CommunityService.CommunityPostService;

public class CommunityPostService : ICommunityPostService
{
    private readonly CobidDbContext _context;
    public CommunityPostService(CobidDbContext context) => _context = context;
    public async Task<ServiceResponse<List<CommunityPost>>> AddCommunityPost(CommunityPost communityPost)
    {
        _context.CommunityPosts.Add(communityPost);
        await _context.SaveChangesAsync();
        return await GetCommunityPostsAsync();
    }

    public async Task<ServiceResponse<List<CommunityPost>>> RemoveCommunityPost(long communityPostId)
    {
        CommunityPost communityPost = await GetCommunityPostById(communityPostId);
        if (communityPost == null)
        {
            return new ServiceResponse<List<CommunityPost>>
            {
                Success = false,
                Message = "Community Post not found"
            };
        }

        communityPost.IsActive = false;
        await _context.SaveChangesAsync();
        return await GetCommunityPostsAsync();
    }

    public async Task<CommunityPost> GetCommunityPostById(long communityPostId)
    {
        return await _context.CommunityPosts.Where(x => x.CommunityPostId == communityPostId).Include(x=>x.CommunityMessages).FirstOrDefaultAsync() ?? new();
    }

    public async Task<ServiceResponse<CommunityPost>> GetCommunityPostAsync(long communityPostId)
    {
        var response = new ServiceResponse<CommunityPost>();
        var communityPost = await _context.CommunityPosts.Where(x =>x.CommunityPostId == communityPostId).Include(x=>x.CommunityMessages).FirstOrDefaultAsync();
        if (communityPost == null)
        {
            response.Success = false;
            response.Message = "Community Post not found";
        }
        else
            response.Data = communityPost;
        return response;
    }

    public async Task<ServiceResponse<List<CommunityPost>>> GetCommunityPostsAsync()
    {
        var response = new ServiceResponse<List<CommunityPost>>
        { Data = await _context.CommunityPosts.Where(x => x.IsActive).Include(x=>x.CommunityMessages).Include(x=>x.CommunityRatings).ToListAsync() };
        return response;
    }

    public async Task<ServiceResponse<List<CommunityPost>>> UpdateCommunityPost(CommunityPost communityPost)
    {
        var dbCommunityPost = await GetCommunityPostById(communityPost.CommunityPostId);
        if (dbCommunityPost == null)
        {
            return new ServiceResponse<List<CommunityPost>>
            {
                Success = false,
                Message = "Community Post not found."
            };
        }

        dbCommunityPost.CommunityPostId= communityPost.CommunityPostId;
        dbCommunityPost.ThreadStaterUserId = communityPost.ThreadStaterUserId;
        dbCommunityPost.CommunityPostTitle = communityPost.CommunityPostTitle;
        dbCommunityPost.CommunityPostType = communityPost.CommunityPostType;
        dbCommunityPost.CommunityMessages = communityPost.CommunityMessages;
        dbCommunityPost.CommunityRatings = communityPost.CommunityRatings;
        dbCommunityPost.IsRead = communityPost.IsRead;
        dbCommunityPost.IsActive =  communityPost.IsActive;

        await _context.SaveChangesAsync();
        return await GetCommunityPostsAsync();
    }
}
