using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace IStore.Data.Common
{
    internal static class CommonQueries
    {
        internal static T GetById<T>(string connectionString, string tableName, int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var query = $"SELECT * FROM {tableName} WHERE id = @id";
                return connection.QuerySingleOrDefault<T>(query, new { id });
            }
        }

        internal static IEnumerable<T> GetAll<T>(string connectionString, string tableName)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var query = $"SELECT * FROM {tableName}";
                return connection.Query<T>(query);
            }
        }

        internal static int DeleteById<T>(string connectionString, string tableName, int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var query = $"DELETE FROM {tableName} WHERE id = @id";
                var affectedRows = connection.Execute(query, new { id });
                return affectedRows;
            }
        }
    }
}
