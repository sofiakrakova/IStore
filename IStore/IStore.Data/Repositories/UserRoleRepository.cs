using Dapper;
using IStore.Data.Interfaces;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IStore.Data.Repositories
{
    public class UserRolesRepository : IRepository<UserRole>
    {
        public static string DefaultTableName => "userroles";
        public string ConnectionString { get; }

        public UserRolesRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Create(UserRole obj)
        {
            throw new NotImplementedException("Unable to create UserRole directly");
        }

        public void Delete(int id)
        {
            throw new NotImplementedException("Unable to delete UserRole directly");

        }

        public UserRole Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.GetByIdQuery(DefaultTableName, id);
                return connection.QueryFirstOrDefault<UserRole>(query);
            }
        }

        public IEnumerable<UserRole> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.GetAllQuery(DefaultTableName);
                return connection.Query<UserRole>(query);
            }
        }

        public void Update(UserRole obj)
        {
            throw new NotImplementedException("Unable to update UserRole directly");
        }
    }
}
