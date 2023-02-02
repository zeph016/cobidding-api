namespace Cobid.Api.Entities.Community;

public class CommunityFileAttachment
{
    public long CommunityFileAttachmentId { get; set; }
    public long CommunityMessageId { get; set; }
    public string CommunityFileAttachmentTitle { get; set; } = string.Empty;
    public string CommunityFileAttachmentData { get; set; } = string.Empty;
    public string CommunityFileAttachmentDescription { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public bool IsActive { get; set; }
}
