using Dapper;
using IStore.Data.Common;
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
        public string TableName { get; } // => "settings";
        public string ConnectionString { get; }

        public SettingsRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members
        
        public int Create(Setting obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {TableName} VALUE(NULL, @key, @value);";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }

        public int Delete(int id)
        {
            int affectedRows = CommonQueries.DeleteById<Setting>(ConnectionString, TableName, id);
            return affectedRows;
        }

        public Setting Get(int id)
        {
            return CommonQueries.GetById<Setting>(ConnectionString, TableName, id);
        }

        public IEnumerable<Setting> GetAll()
        {
            return CommonQueries.GetAll<Setting>(ConnectionString, TableName);
        }

        public int Update(Setting obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"UPDATE {TableName} 
                               SET `key` = @key, value = @value
                               WHERE id = @id;";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }
        #endregion

        #region ISettingsRepository members

        public Setting GetByKey(string key)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"SELECT * FROM {TableName} WHERE `key` = @key";
                return connection.QueryFirstOrDefault<Setting>(query, new { key });
            }
        }
        #endregion
    }
}
