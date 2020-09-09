namespace IStore.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public int? Parent_Id { get; set; }
        public string Text { get; set; }
        public int Product_Id { get; set; }
        public int? User_Id { get; set; }
    }
}
