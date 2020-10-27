using System.Collections.Generic;

namespace IStore.Data.Interfaces
{
    public interface IRepository<T>
    {
        string TableName { get; }
        string ConnectionString { get; }

        int Create(T obj);
        T Get(int id);
        IEnumerable<T> GetAll();
        int Update(T obj);
        int Delete(int id);
    }
}
