namespace Cobid.Api.Entities.Cart
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public bool isCompleted { get; set; }
    }
}
