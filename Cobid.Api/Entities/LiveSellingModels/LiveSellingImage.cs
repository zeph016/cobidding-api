using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.LiveSellingModels
{
    public class LiveSellingImage
    {
        public long LiveSellingImageId { get; set; }
        public long LiveSellingId { get; set; }
        public string LiveSellingImageTitle { get; set; } = string.Empty;
        public string LiveSellingImageUrl { get; set; } = string.Empty;
        public string LiveSellingDataImage { get; set;} = string.Empty;
        public bool IsActive { get; set; }
        [NotMapped]
        public bool IsEdit { get; set; }
        [NotMapped]
        public bool IsNew { get; set; }
    }
}
