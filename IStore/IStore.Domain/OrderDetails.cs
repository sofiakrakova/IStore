using System;

namespace IStore.Domain
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Address { get; set; }
        public string PaymentType { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public User User { get; set; }
    }
}
