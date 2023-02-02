namespace Cobid.Api.Entities.Product
{
    public class ProductRatingImage
    {
        public long ProductRatingImageId { get; set; }
        public long ProductRatingId { get; set; }
        public string ProductRatingImageName { get; set; } = string.Empty;
        public string ProductRatingImageLocation { get; set; } = string.Empty;
        public string ProductRatingImageData { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
