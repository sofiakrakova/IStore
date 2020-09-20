using IStore.Domain;

namespace IStore.Data
{
    public interface IUsersRepository : IRepository<User>
    {
        public User GetByEmail(string email);
    }
}
