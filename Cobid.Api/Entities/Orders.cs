namespace Cobid.Api.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public long OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderShipDate { get; set; }
        public int ShipperId { get; set; }
        public int TransactStatusId { get; set; }
        public bool isCompleted { get; set; }
        public int CartId { get; set; }
    }
}
