namespace Cobid.Api.Entities.Community;

public class CommunityPostRating
{
    public long CommunityPostRatingId { get; set; }
    public long CommunityPostId { get; set; }
    public int UserId { get; set; }
    public long CommunityPostRatingLike { get; set; }
    public long CommunityPostRatingDislike { get; set; }
    public int CommunityPostRatingGrade { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsActive { get; set; }
}
