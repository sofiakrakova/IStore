using IStore.BusinessLogic.Services;
using IStore.BusinessLogic.Services.Interfaces;
using IStore.Data.Interfaces;
using IStore.Data.Repositories;
using IStore.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("IStore.BusinessLogic")]

namespace IStore.BusinessLogic.Tests.Services
{
    [TestClass]
    public class UsersManagementServiceTests
    {
        private string _connectionString;
        private IUsersRepository _usersRepository;
        private ISettingsRepository _settingsRepository;
        private IUsersManagementService _usersManagementService;

        [TestInitialize]
        public void Setup()
        {
            _connectionString = "Server=localhost;Database=istoredb_test;User Id=root;Password=admin";

            _usersRepository = new UsersRepository(_connectionString, "users");
            _settingsRepository = new SettingsRepository(_connectionString, "settings");

            _usersManagementService = new UsersManagementService(_usersRepository, _settingsRepository);
        }

        [TestMethod]
        public void CreateValidUserTest()
        {
            var user = _usersManagementService.CreateNew(
                credentials: "Alexey Popov",
                email: "alexeypopov@istore.com",
                passwordhash: "##123abc==",
                birthday: new DateTime(1992, 4, 1),
                about: "Bio");

            Assert.IsNotNull(user);

            _usersManagementService.Delete(user.Email);
        }

        [TestMethod]
        public void CreateNewAssingCorrectFields()
        {
            var user = _usersManagementService.CreateNew(
                credentials: "Alexey Popov",
                email: "alexeypopov@istore.com",
                passwordhash: "##123abc==",
                birthday: new DateTime(1992, 4, 1),
                about: "Bio");

            Assert.IsTrue(user.Id > 0);
            Assert.AreEqual(user.Credentials, "Alexey Popov");
            Assert.AreEqual(user.Email, "alexeypopov@istore.com");
            Assert.AreEqual(user.PasswordHash, "##123abc==");
            Assert.AreEqual(user.Birthday, new DateTime(1992, 4, 1));
            Assert.AreEqual(user.Comment, "Bio");
            Assert.AreEqual(user.UserRole_Id, user.UserRole.Id);
            Assert.AreEqual(user.UserRole_Id, (int)UserRoleType.User);

            _usersManagementService.Delete(user.Email);
        }

        [TestMethod]
        public void CreateUserWithoutAbout()
        {
            var user = _usersManagementService.CreateNew(
                credentials: "Alexey Popov",
                email: "alexeypopov@istore.com",
                passwordhash: "##123abc==",
                birthday: new DateTime(1992, 4, 1),
                about: null);

            Assert.IsNotNull(user);

            _usersManagementService.Delete(user.Email);
        }
    }
}
