using System.Diagnostics;

namespace IStore.Domain
{
    [DebuggerDisplay("id:{Id} {Title}")]
    public class Category
    {
        public int Id { get; set; }
        public int? Parent_Id { get; set; }
        public string Title { get; set; }
    }
}
