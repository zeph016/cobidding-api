namespace Cobid.Api.Entities.Product
{
    public class ProductSubCategory
    {
        public int ProductSubCategoryId { get; set; }
        public string ProductSubCategoryName { get; set; } = string.Empty;
        public string ProductSubCategoryDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
