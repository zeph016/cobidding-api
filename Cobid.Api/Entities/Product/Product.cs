using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.Product
{
    public class Product
    {
        public long ProductId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int ProductCategoryId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
        public int ProductConditionId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Length { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Width { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Height { get; set; }
        public int DimensionModelId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }
        public int WeightModelId { get; set; }
        public int ProductRanking { get; set; }
        public int ProductStatusId { get; set; }
        public int ProductListedAs { get; set; }
        public int ProductRating { get; set; }
        public int ProductStockCount { get; set; }
        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public List<ProductRating> ProductRatings { get; set; } = new List<ProductRating>();
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsSale { get; set;  }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaleAmt { get; set; }
        public string AdminRemarks { get; set; } = string.Empty;
    }
}
