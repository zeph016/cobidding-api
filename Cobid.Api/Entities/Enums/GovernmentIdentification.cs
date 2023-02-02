using System.ComponentModel.DataAnnotations.Schema;

namespace Cobid.Api.Entities.Enums
{
    public class GovernmentIdentification
    {
        public int GovernmentIdentificationId { get; set; }
        public string GovIdName { get; set; } = string.Empty;
        public string GovIdShortName { get; set; } = string.Empty;  
        public bool isActive { get; set; }
    }
}
