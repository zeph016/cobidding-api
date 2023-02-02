using System.ComponentModel.DataAnnotations;

namespace Cobid.Api.Entities.Enums
{
    public class ProductListedAs
    {
        public int ProductListedAsId { get; set; }
        public string ProductListedAsName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
