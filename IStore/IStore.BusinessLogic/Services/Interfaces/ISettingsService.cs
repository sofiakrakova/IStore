using IStore.Domain;

namespace IStore.BusinessLogic.Services.Interfaces
{
    public interface ISettingsService
    {
        string GetValue(string key);
        Setting Add(string key, string value);
        void Remove(string key);
    }
}
