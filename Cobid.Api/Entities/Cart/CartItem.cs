namespace Cobid.Api.Entities.Cart
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public long ProductId { get; set; }
        public int Qty { get; set; }
        public bool isCompleted { get; set; }
    }
}
