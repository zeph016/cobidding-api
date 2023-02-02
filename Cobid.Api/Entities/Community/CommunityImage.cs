namespace Cobid.Api.Entities.Community;

public class CommunityImage
{
    public long CommunityImageId { get; set; }
    public long CommunityMessageId { get; set; }
    public string CommunityImageLocation { get; set; } = string.Empty;
    public string CommunityDataImage { get; set; } = string.Empty;
    public string CommunityImageTitle { get; set; } = string.Empty;
    public string CommunityImageDescription { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public bool IsActive { get; set; }
}
