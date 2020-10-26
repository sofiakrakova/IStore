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
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {DefaultTableName} VALUE(NULL, '{obj.Credentials}', '{obj.Email}', '{obj.PasswordHash}', '{RepositoryUtils.DateTimeToString(obj.Birthday)}', '{MySqlHelper.EscapeString(obj.Comment)}', {obj.UserRole_Id});";
                var affectedRows = connection.Execute(query);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.DeleteByIdQuery(DefaultTableName, id);
                var affectedRows = connection.Execute(query);
            }
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
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.GetAllQuery(DefaultTableName);
                return connection.Query<User>(query);
            }
        }
        public void Update(User obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"UPDATE {DefaultTableName} 
SET credentials={obj.Credentials}, birthday='{obj.Birthday}', passwordhash={obj.PasswordHash}, comment={obj.Comment}, userrole=
{obj.UserRole};
WHERE id={obj.Id};";

                var affectedRows = connection.Execute(query);
            }
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
