using IStore.Domain;

namespace IStore.BusinessLogic.Services
{
    public interface IDatabaseSettingsService
    {
        string GetValue(string key);
        Setting Add(string key, string value);
        void Remove(string key);
    }
}
