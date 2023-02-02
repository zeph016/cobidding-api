using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.LiveSellingModels
{
    public class LiveSelling
    {
        public long LiveSellingId { get; set; }
        public int UserId { get; set; }
        public string LiveSellingTitle { get; set; } = string.Empty;
        public string LiveSellingPassword { get; set; } = string.Empty;
        public string LiveSellingDescription { get; set; } = string.Empty;
        public string LiveSellingLink { get; set; } = string.Empty;
        public DateTime LiveSellingDateStart { get; set; }
        public DateTime LiveSellingDateEnd { get; set; }
        public List<LiveSellingImage> LiveSellingImages { get; set; } = new List<LiveSellingImage>();
        public bool IsActive { get; set; } = true;
        public bool HasEnded { get; set; }
        public bool Deleted { get; set; }
        [NotMapped]
        public bool IsEdit { get; set; }
        [NotMapped]
        public bool IsNew { get; set; }
    }
}
