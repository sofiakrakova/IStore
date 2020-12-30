using IStore.Domain;

namespace IStore.Data.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        public User GetByEmail(string email);
    }
}
