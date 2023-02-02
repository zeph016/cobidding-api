namespace Cobid.Api.Entities.Product
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; } = string.Empty;
        public string ProductCategoryDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
