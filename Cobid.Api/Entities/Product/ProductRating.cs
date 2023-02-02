using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.Product
{
    public class ProductRating
    {
        public long ProductRatingId { get; set; }
        public int UserId { get; set; }
        public long ProductId { get; set; }
        public string ProductRatingDescription { get; set; } = string.Empty;
        public int ProductRatingGrade { get; set; }
        public string ProductRatingComment { get; set; } = string.Empty;
        public List<ProductRatingImage> ProductRatingImages { get; set; } = new List<ProductRatingImage>();
        public DateTime DateCreated { get; set; }
        public bool isActive { get; set; }
    }
}
