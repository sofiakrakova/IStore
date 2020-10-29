using Dapper;
using IStore.Data.Common;
using IStore.Data.Interfaces;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IStore.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public string TableName { get; } // => "users";
        public string ConnectionString { get; }

        public UsersRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members

        public int Create(User obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"INSERT INTO {TableName} VALUE(NULL, @credentials, @email, @passwordhash, @birthday, @comment, @userrole_id);";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }

        public int Delete(int id)
        {
            int affectedRows = CommonQueries.DeleteById<User>(ConnectionString, TableName, id);
            return affectedRows;
        }

        public User Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM users AS u
                            JOIN userroles AS r
                            ON u.userrole_id = r.id
                            WHERE u.id = @id;";

                var result = connection.Query<User, UserRole, User>(query, (user, userrole) =>
                {
                    user.UserRole = userrole;
                    return user;
                },
                splitOn: "id",
                param: new { id });

                return result.SingleOrDefault();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM users AS u
                            JOIN userroles AS r
                            ON u.userrole_id = r.id;";

                return connection.Query<User, UserRole, User>(query, (user, userrole) =>
                {
                    user.UserRole = userrole;
                    return user;
                },
                splitOn: "id");
            }
        }

        public int Update(User obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"UPDATE {TableName} 
                            SET 
                                credentials = @credentials, 
                                email = @email, 
                                passwordhash = @passwordhash, 
                                birthday = @birthday, 
                                comment = @comment, 
                                userrole = @userrole;
                            WHERE id = @id;";

                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }
        #endregion

        #region IUsersRepository members

        public User GetByEmail(string email)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM users AS u
                            JOIN userroles AS r
                            ON u.userrole_id = r.id
                            WHERE u.email = @email;";

                var result = connection.Query<User, UserRole, User>(query, (user, userrole) =>
                {
                    user.UserRole = userrole;
                    return user;
                },
                splitOn: "id",
                param: new { email });

                return result.SingleOrDefault();
            }
        }
        #endregion
    }
}
