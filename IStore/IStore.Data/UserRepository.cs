using Dapper;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IStore.Data
{
    public class UserRepository : IRepository<User>
    {
        public static string DefaultTableName => "users";
        public string ConnectionString { get; }

        public UserRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public void Create(User obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.GetByIdQuery(DefaultTableName, id);
                
                var user = connection.QueryFirstOrDefault<User>(query);
                //TODO: user null check
                
                var userRoleQuery = RepositoryUtils.GetByIdQuery(UserRoleRepository.DefaultTableName, user.UserRole_Id);
                var userRole = connection.QueryFirstOrDefault<UserRole>(userRoleQuery);

                user.UserRole = userRole;
                return user;
            }
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
