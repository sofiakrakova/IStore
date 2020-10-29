using IStore.BusinessLogic.Security;
using IStore.Data.Interfaces;
using IStore.Domain;
using IStore.Domain.Enums;
using System;

namespace IStore.BusinessLogic.Services
{
    public class UsersManagementService : IUsersManagementService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ISettingsRepository _settingsRepository;
        private readonly IStringEncryptor _encryptor;

        public UsersManagementService(IUsersRepository usersRepository, ISettingsRepository settingsRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _settingsRepository = settingsRepository ?? throw new ArgumentNullException(nameof(settingsRepository));

            _encryptor = new StringEncryptor(_settingsRepository);
        }

        public User CreateNew(string credentials, string email, string password, DateTime birthday, string about)
        {
            if (string.IsNullOrWhiteSpace(credentials)) throw new ArgumentException($"Invalid credentials: '{credentials}'.");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException($"Invalid email: '{email}'.");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException($"Invalid passwordhash: '{password}'.");
            if (birthday > DateTime.Now) throw new ArgumentException($"Birthday cannot be in the future: '{birthday}'.");

            var existingEncryptedUser = this.GetByEmail(email);
            if (existingEncryptedUser != null)
                throw new Exception($"User with email {email} already exists.");

            User newEncryptedUser = new User()
            {
                Credentials = credentials,
                Email = email,
                PasswordHash = SecurityUtilities.Hash(password),
                Birthday = birthday.ToShortDateString(),
                Comment = about,
                UserRole_Id = (int)UserRoleType.User
            }
            .Encrypt(_encryptor);

            _usersRepository.Create(newEncryptedUser);

            return _usersRepository.GetByEmail(newEncryptedUser.Email)?.Decrypt(_encryptor);
        }

        public void Delete(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException($"Invalid email: '{email}'.");

            var encryptedUser = this.GetByEmail(email);
            if (encryptedUser == null)
                throw new Exception($"User with email '{email}' is not found.");

            _usersRepository.Delete(encryptedUser.Id);
        }

        public User GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException($"Invalid email: '{email}'.");

            var encryptedEmail = _encryptor.EncryptString(email);
            var encryptedUser = _usersRepository.GetByEmail(encryptedEmail);
            return encryptedUser?.Decrypt(_encryptor);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return SecurityUtilities.Verify(password, hash);
        }
    }
}
