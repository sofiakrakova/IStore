namespace IStore.Domain
{
    public class Discount
    {
        public int Id { get; set; }
        public int Category_Id { get; set; }
        public int AmountPercent { get; set; }


        public Category Category { get; set; }
    }
}
