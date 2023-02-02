namespace Cobid.Api.Entities.Product
{
    public class ProductView
    {
        public long ProductViewId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public long ProductViewCount { get; set; }
        public long ProductFavoriteCount { get; set; }
    }
}
