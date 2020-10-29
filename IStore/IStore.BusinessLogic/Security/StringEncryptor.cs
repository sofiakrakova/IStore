using IStore.Data.Interfaces;
using IStore.Domain;
using System;
using System.IO;
using System.Security.Cryptography;

namespace IStore.BusinessLogic.Security
{
    public class StringEncryptor : IStringEncryptor
    {
        const string AES_KEY = "AesKey";
        const string AES_IV = "AesIV";

        private readonly ISettingsRepository _settingsRepository;

        private byte[] _aesKey;
        private byte[] _aesIV;

        public StringEncryptor(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;

            var aesKeySetting = settingsRepository.GetByKey(AES_KEY);
            var aesIVSetting = settingsRepository.GetByKey(AES_IV);

            _aesKey = Convert.FromBase64String(aesKeySetting.SettingValue);
            _aesIV = Convert.FromBase64String(aesIVSetting.SettingValue);

            //if (aesKeySetting == null && aesIVSetting == null)
            //{
            //    ConfigureAesSettings();
            //}
            //else
            //{
            //    _aesKey = Convert.FromBase64String(aesKeySetting.SettingValue);
            //    _aesIV = Convert.FromBase64String(aesIVSetting.SettingValue);
            //}
        }

        [Obsolete]
        private void ConfigureAesSettings()
        {
            Setting aesKeySetting;
            Setting aesIVSetting;

            using (var aes = Aes.Create())
            {
                aesKeySetting = new Setting() { SettingKey = AES_KEY, SettingValue = Convert.ToBase64String(aes.Key) };
                aesIVSetting = new Setting() { SettingKey = AES_IV, SettingValue = Convert.ToBase64String(aes.IV) };

                _aesKey = new byte[aes.Key.Length];
                _aesIV = new byte[aes.IV.Length];
                Array.Copy(aes.Key, _aesKey, _aesKey.Length);
                Array.Copy(aes.IV, _aesIV, _aesIV.Length);
            }

            _settingsRepository.Create(aesKeySetting);
            _settingsRepository.Create(aesIVSetting);
        }

        public string EncryptString(string plain)
        {
            byte[] encryptedData;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _aesKey;
                aesAlg.IV = _aesIV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plain);
                    }
                    encryptedData = msEncrypt.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedData);
        }

        public string DecryptString(string encrypted)
        {
            byte[] data = Convert.FromBase64String(encrypted);
            string plainText = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _aesKey;
                aesAlg.IV = _aesIV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(data))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    plainText = srDecrypt.ReadToEnd();
                }
            }

            return plainText;
        }
    }
}
