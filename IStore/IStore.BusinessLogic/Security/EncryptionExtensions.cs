using IStore.Domain;

namespace IStore.BusinessLogic.Security
{
    internal static class EncryptionExtensions
    {
        internal static User Encrypt(this User user, IStringEncryptor encryptor)
        {
            user.Credentials = encryptor.EncryptString(user.Credentials);
            user.Birthday = encryptor.EncryptString(user.Birthday);
            user.Email = encryptor.EncryptString(user.Email);
            user.Comment = encryptor.EncryptString(user.Comment);

            return user;
        }

        internal static User Decrypt(this User user, IStringEncryptor encryptor)
        {
            user.Credentials = encryptor.DecryptString(user.Credentials);
            user.Birthday = encryptor.DecryptString(user.Birthday);
            user.Email = encryptor.DecryptString(user.Email);
            user.Comment = encryptor.DecryptString(user.Comment);

            return user;
        }
    }
}
