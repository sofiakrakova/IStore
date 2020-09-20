using Dapper;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IStore.Data
{
    public class UsersRepository : IUsersRepository
    {
        public static string DefaultTableName => "users";
        public string ConnectionString { get; }

        public UsersRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #region IRepository<User> members

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

                var userRoleQuery = RepositoryUtils.GetByIdQuery(UserRolesRepository.DefaultTableName, user.UserRole_Id);
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
        #endregion

        #region IUsersRepository memebers

        public User GetByEmail(string email)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.GetByEmailQuery(DefaultTableName, email);

                var user = connection.QueryFirstOrDefault<User>(query);
                //TODO: user null check

                var userRoleQuery = RepositoryUtils.GetByIdQuery(UserRolesRepository.DefaultTableName, user.UserRole_Id);
                var userRole = connection.QueryFirstOrDefault<UserRole>(userRoleQuery);

                user.UserRole = userRole;
                return user;
            }
        }
        #endregion
    }
}
