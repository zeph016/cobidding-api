namespace Cobid.Api.Entities.Product
{
    public class ProductCondition
    {
        public int ProductConditionId { get; set; }
        public string ProductConditionName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
