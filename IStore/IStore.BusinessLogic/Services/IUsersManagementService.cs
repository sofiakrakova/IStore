using IStore.Domain;
using System;

namespace IStore.BusinessLogic.Services
{
    public interface IUsersManagementService
    {
        /// <summary>
        /// Creates and returns a new user.
        /// </summary>
        User CreateNew(string credentials, string email, string passwordhash, DateTime birthday, string about);

        /// <summary>
        /// Deletes user by Email
        /// </summary>
        void Delete(string email);

        User GetByEmail(string email);

        bool VerifyPassword(string password, string hash);
    }
}
