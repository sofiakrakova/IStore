namespace IStore.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Qty { get; set; }
        public int Details_Id { get; set; }

        public Product Product { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
