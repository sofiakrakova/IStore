using IStore.BusinessLogic.Security;
using IStore.BusinessLogic.Services;
using IStore.Data;
using IStore.Data.Interfaces;
using IStore.Data.Repositories;
using IStore.Domain;
using IStore.Domain.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace IStore.Sandbox
{
    class Program
    {
        static string connectionString = null;

        static void InitConnection()
        {
            DbConnectionStringBuilder dbsb = new DbConnectionStringBuilder();
            dbsb.Add("Server", "localhost");
            dbsb.Add("Database", "istoredb");
            dbsb.Add("User Id", "root");
            dbsb.Add("Password", "admin");

            connectionString = dbsb.ConnectionString;
        }

        static void Main(string[] args)
        {
            InitConnection();

            //QuerySupplierProducts();
            //QuerySettings();
            //QueryProducts();
            //string adminPass = "user";
            //var hash = BCrypt.Net.BCrypt.HashPassword(adminPass);

            //string pass = "user";
            //var b = BCrypt.Net.BCrypt.Verify(pass, hash);
            QueryUsers();
            //QueryCategories();
            //QueryUserRoles();

            //DataEncriptionTest();
        }

        static void QuerySettings()
        {
            SettingsRepository settingsRepository = new SettingsRepository(connectionString, "settings");

            var s = settingsRepository.Get(1);

            if (s == null)
                settingsRepository.Create(new Setting() { SettingKey = "AesIV", SettingValue = "::\"bla'+" });

            s = settingsRepository.GetByKey("AesIV");
            s.SettingValue += "upd.";
            settingsRepository.Update(s);
        }

        static void QueryUserRoles()
        {
            UserRolesRepository userRolesRepository = new UserRolesRepository(connectionString, "userroles");

            var roles = userRolesRepository.GetAll();
        }

        static void QueryProducts()
        {
            ProductsRepository productsRepository = new ProductsRepository(connectionString, "products");

            var products = productsRepository.GetAll();
        }

        static void QuerySupplierProducts()
        {
            SupplierProductsRepository supplierProductRepository = new SupplierProductsRepository(connectionString, "supplier_products");

            var supplierProducts = supplierProductRepository.GetAll();
        }

        static void QueryUsers()
        {
            IUsersRepository usersRepository = new UsersRepository(connectionString, "users");
            ISettingsRepository settingsRepository = new SettingsRepository(connectionString, "settings");
            IUsersManagementService usersManagementService = new UsersManagementService(
                usersRepository,
                settingsRepository);

            //create default
            //usersManagementService.CreateNew(
            //    "Test Administrator",
            //    "admin@istore.com",
            //    "$2b$10$n45gXcwVp4Niyr385xh.CevsQWP3xRNCck/fLJ6Honn4URJMV6VgK",
            //    DateTime.Now,
            //    "Administrator account for test purposes");

            //usersManagementService.CreateNew(
            //    "Test User",
            //    "user@istore.com",
            //    "$2b$10$Jme/D8ENr09qQYcydWHknOQ2LA0RoUYPLJjfKiTjkWW3I5jdgkdnu",
            //    DateTime.Now,
            //    "User account for test purposes");

            //get
            var admin = usersManagementService.GetByEmail("admin@istore.com");

            //create
            User alreadyCreatedUser = usersManagementService.CreateNew(
                "Temp User",
                "temp@istore.com",
                "querty123",
                new DateTime(1990, 10, 4),
                "Comment");

            //delete
            var temp = usersManagementService.GetByEmail("temp@istore.com");
            usersManagementService.Delete(temp.Email);
        }

        static void QueryCategories()
        {
            CategoriesRepository categoryRepository = new CategoriesRepository(connectionString, "categories");
            List<Category> categories = categoryRepository.GetAll().ToList();

            var headphones = categories.Single(x => x.Title == "Headphones");
            headphones.Active = false;
            categoryRepository.Update(headphones);
        }
    }
}
