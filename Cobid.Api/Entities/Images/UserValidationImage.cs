using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Cobid.Api.Entities.Images
{
    public class UserValidationImage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public string ImageHttpLocation { get; set; } = string.Empty;
        public string DataImage { get; set; } = string.Empty;
        public string IdTypeName { get; set; } = string.Empty;
        public int GovernmentIdentificationId { get; set; }
        public bool IsActive { get; set; }
        public bool IsValidated { get; set; }
        public bool IsNew { get; set; }
    }
}
