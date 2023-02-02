namespace Cobid.Api.Entities.Product
{
    public class ProductImage
    {
        public long ProductImageId { get; set; }
        public long ProductId { get; set; }
        public string ProductImageLocation { get; set; } = string.Empty;
        public string ProductDataImage { get; set; } = string.Empty;
        public string ProductImageTitle { get; set; } = string.Empty;
        public string ProductImageDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
