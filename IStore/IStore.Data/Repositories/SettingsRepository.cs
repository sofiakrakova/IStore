using Dapper;
using IStore.Data.Interfaces;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IStore.Data.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        public string DefaultTableName => "settings";
        public string ConnectionString { get; }

        public SettingsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public Setting GetByKey(string key)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"SELECT * FROM {DefaultTableName} WHERE `key` = @key";
                return connection.QueryFirstOrDefault<Setting>(query, new { key });
            }
        }

        public void Create(Setting obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {DefaultTableName} VALUE(NULL, @key, @value);";
                var affectedRows = connection.Execute(query, obj);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Setting Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"SELECT * FROM {DefaultTableName} WHERE id = @id";
                return connection.QueryFirstOrDefault<Setting>(query, new { id });
            }
        }

        public IEnumerable<Setting> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Setting obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"UPDATE {DefaultTableName} 
                               SET `key` = @key, value = @value
                               WHERE id = @id;";
                var affectedRows = connection.Execute(query, obj);
            }
        }
    }
}
