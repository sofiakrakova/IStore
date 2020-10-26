using Dapper;
using IStore.Data.Interfaces;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace IStore.Data.Repositories
{
    public class CategoriesRepository : IRepository<Category>
    {
        public string DefaultTableName => "categories";
        public string ConnectionString { get; }

        public CategoriesRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Create(Category obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                int active = obj.Active ? 1 : 0;
                var query = $"INSERT INTO {DefaultTableName} VALUE(NULL, {obj.Parent_Id}, '{obj.Title}', {active});";
                var affectedRows = connection.Execute(query);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.DeleteByIdQuery(DefaultTableName, id);
                var affectedRows = connection.Execute(query);

                //TODO: what if (affectedRows != 1) ?
            }
        }

        public Category Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.GetByIdQuery(DefaultTableName, id);
                return connection.QueryFirstOrDefault<Category>(query);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = RepositoryUtils.GetAllQuery(DefaultTableName);
                return connection.Query<Category>(query);
            }
        }

        public void Update(Category obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                int active = obj.Active ? 1 : 0;

                //TODO: deal with null values (does they need to be converted to NULL?)
                var query = $@"UPDATE {DefaultTableName} 
SET parent_id={obj.Parent_Id}, title='{obj.Title}', active={active}
WHERE id={obj.Id};";
                
                var affectedRows = connection.Execute(query);
            }
        }
    }
}
