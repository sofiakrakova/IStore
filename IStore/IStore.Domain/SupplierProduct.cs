using System;

namespace IStore.Domain
{
    public class SupplierProduct
    {
        public int Id { get; set; }
        public int Supplier_Id { get; set; }
        public int Product_Id { get; set; }
        public DateTime DeliveryPeriod { get; set; }

        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
    }
}
