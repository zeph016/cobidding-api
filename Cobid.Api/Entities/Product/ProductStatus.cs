namespace Cobid.Api.Entities.Product
{
    public class ProductStatus
    {
        public int ProductStatusId { get; set; }
        public string ProductStatusName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
