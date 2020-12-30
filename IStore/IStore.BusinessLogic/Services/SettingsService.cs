using IStore.BusinessLogic.Services.Interfaces;
using IStore.Data.Interfaces;
using IStore.Domain;
using System;

namespace IStore.BusinessLogic.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsService(ISettingsRepository settingsRepository)
        {
            Protector.SetIfNotNull(ref _settingsRepository, settingsRepository);
        }

        public Setting Add(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException($"Invalid key: '{key}'.");

            var existingSetting = _settingsRepository.GetByKey(key);
            if (existingSetting != null)
                throw new Exception($"Key '{key}' already exists.");

            Setting newSetting = new Setting() { SettingKey = key, SettingValue = value };

            _settingsRepository.Create(newSetting);

            return _settingsRepository.GetByKey(newSetting.SettingKey);
        }

        public string GetValue(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException($"Invalid key: '{key}'.");

            var setting = _settingsRepository.GetByKey(key);
            if (setting == null)
                throw new Exception($"Setting with key '{key}' not found.");

            return setting.SettingValue;
        }

        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException($"Invalid key: '{key}'.");

            var setting = _settingsRepository.GetByKey(key);
            if (setting == null)
                throw new Exception($"Setting with key '{key}' not found.");

            _settingsRepository.Delete(setting.Id);
        }
    }
}
