using IStore.Data;
using IStore.Domain;
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

            string adminPass = "user";
            var hash = BCrypt.Net.BCrypt.HashPassword(adminPass);

            string pass = "user";
            var b = BCrypt.Net.BCrypt.Verify(pass, hash);
            QueryCategories();
            QueryUserRoles();
            QueryUsers();
        }

        static void QueryUserRoles()
        {
            UserRolesRepository userRolesRepository = new UserRolesRepository(connectionString);
            
            var roles = userRolesRepository.GetAll();
        }

        static void QueryUsers()
        {
            UsersRepository usersRepository = new UsersRepository(connectionString);

            var user = usersRepository.Get(1);
        }

        static void QueryCategories()
        {
            CategoriesRepository categoryRepository = new CategoriesRepository(connectionString);
            List<Category> categories = categoryRepository.GetAll().ToList();

            var headphones = categories.Single(x => x.Title == "Headphones");
            headphones.Active = false;
            categoryRepository.Update(headphones);
        }
    }
}
