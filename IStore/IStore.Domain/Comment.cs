using System;

namespace IStore.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public int? ParentId { get; set; }
        
        public DateTime Timestamp { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}
