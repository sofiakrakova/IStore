using System.Collections.Generic;

namespace IStore.Data.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T obj);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Delete(int id);
    }
}
