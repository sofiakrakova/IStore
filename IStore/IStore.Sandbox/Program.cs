using IStore.BusinessLogic.Security;
using IStore.Data;
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
            //QueryUsers();
            //QueryCategories();
            //QueryUserRoles();

            //DataEncriptionTest();
        }

        static void DataEncriptionTest()
        {
            DataEncryptor dataEncryptor = new DataEncryptor(new SettingsRepository(connectionString, "settings"));

            string original = "Here is some data to encrypt!";

            byte[] encrypted = dataEncryptor.EncryptString(original);

            string roundtrip = dataEncryptor.DecryptString(encrypted);
        }

        static void QuerySettings()
        {
            SettingsRepository settingsRepository = new SettingsRepository(connectionString, "settings");

            var s = settingsRepository.Get(1);

            if (s == null)
                settingsRepository.Create(new Setting() { Key = "AesIV", Value = "::\"bla'+" });

            s = settingsRepository.GetByKey("AesIV");
            s.Value += "upd.";
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
            UsersRepository usersRepository = new UsersRepository(connectionString, "users");

            //get
            var users = usersRepository.GetAll();
            var admin = usersRepository.GetByEmail("admin@istore.com");
            var daria = usersRepository.Get(3);

            //create
            User tempUser = new User()
            {
                Email = "temp@istore.com",
                Birthday = new DateTime(1990, 10, 4),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("querty123"),
                Credentials = "Temp Temp",
                Comment = "Comment",
                UserRole_Id = (int)UserRoleType.User
            };
            var affectedRows1 = usersRepository.Create(tempUser);

            //delete
            var temp = usersRepository.GetByEmail("temp@istore.com");
            var affectedRows2 = usersRepository.Delete(temp.Id);
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
