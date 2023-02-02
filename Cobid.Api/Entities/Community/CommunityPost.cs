using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.Community;

public class CommunityPost
{
    public long CommunityPostId { get; set; }
    public int ThreadStaterUserId { get; set; }
    public string CommunityPostTitle { get; set; } = string.Empty;
    public long CommunityPostType { get; set; }
    public List<CommunityMessage> CommunityMessages { get; set; } = new List<CommunityMessage>();
    public List<CommunityPostRating> CommunityRatings { get; set; } = new List<CommunityPostRating>();
    public DateTime DateCreated { get; set;  }
    public bool IsRead {  get; set; }
    public bool IsActive { get; set; }
}
