namespace Cobid.Api.Entities
{
    public class Shippers
    {
        public int ShipperId { get; set; }
        public string ShipperName { get; set; } = string.Empty;
        public string ShipperEmail { get; set; } = string.Empty;
        public int ShipperPhone { get; set; }
    }
}
