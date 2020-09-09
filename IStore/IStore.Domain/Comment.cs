namespace IStore.Domain
{
    public class Comment
    {
        public int Comment_Id { get; set; }
        public int? ParentComment_Id { get; set; }
        public int Product_Id { get; set; }
        public string Text { get; set; }
        public int? User_Id { get; set; }
    }
}
