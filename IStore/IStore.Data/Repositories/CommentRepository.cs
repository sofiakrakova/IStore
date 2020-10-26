using Dapper;
using IStore.Data.Interfaces;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace IStore.Data.Repositories
{
    public class CommentsRepository : IRepository<Comment>
    {
        public static string DefaultTableName => "comments";
        public string ConnectionString { get; }

        public CommentsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Create(Comment obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {DefaultTableName} VALUE(NULL, {obj.Parent_Id}, '{obj.Text}', {obj.Product_Id}, {obj.User_Id});";
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

        public Comment Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.GetByIdQuery(DefaultTableName, id);
                return connection.QueryFirstOrDefault<Comment>(query);
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.GetAllQuery(DefaultTableName);
                return connection.Query<Comment>(query);
            }
        }

        public void Update(Comment obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"UPDATE {DefaultTableName} 
SET parent_id={obj.Parent_Id}, text='{obj.Text}', product_id={obj.Product_Id}, user_id={obj.User_Id}
WHERE id={obj.Id};";

                var affectedRows = connection.Execute(query);
            }
        }
    }
}
