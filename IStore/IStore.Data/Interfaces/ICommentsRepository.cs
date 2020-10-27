using IStore.Domain;

namespace IStore.Data.Interfaces
{
    public interface ICommentsRepository : IRepository<Comment>
    {
        int Attach(int parentId, Comment child);
        int CreateRoot(Comment comment);
        int DeleteWithChildren(int parentId);
    }
}
