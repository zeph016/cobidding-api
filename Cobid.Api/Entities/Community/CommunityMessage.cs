namespace Cobid.Api.Entities.Community;

public class CommunityMessage
{
    public long CommunityMessageId { get; set; }
    public long CommunityPostId { get; set; }
    public int SenderId { get; set; }
    public string MessageContent { get; set; } = string.Empty;
    public List<CommunityImage> Images { get; set; } = new List<CommunityImage>();
    public List<CommunityFileAttachment> FileAttachments { get; set; } = new List<CommunityFileAttachment>();
    public DateTime DateSent { get; set; }
    public bool IsRead { get; set; }
    public bool IsActive { get; set; }
}
