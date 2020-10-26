using IStore.Domain;

namespace IStore.Data.Interfaces
{
    public interface ISettingsRepository : IRepository<Setting>
    {
        Setting GetByKey(string key);
    }
}
