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
    public class ProductsRepository : IProductsRepository
    {
        public string TableName { get; } // => "products";
        public string ConnectionString { get; }

        public ProductsRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members

        public int Create(Product obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {TableName} VALUE(NULL, @title, @description, @price, @image, @category_id);";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }

        public int Delete(int id)
        {
            var affectedRows = CommonQueries.DeleteById<Product>(ConnectionString, TableName, id);
            return affectedRows;
        }

        public Product Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS p
                            JOIN categories AS c
                            ON p.category_id = c.id
                            WHERE p.id = @id;";

                var result = connection.Query<Product, Category, Product>(query, (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                splitOn: "id",
                param: new { id });

                return result.SingleOrDefault();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS p
                            JOIN categories AS c
                            ON p.category_id = c.id;";

                var result = connection.Query<Product, Category, Product>(query, (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                splitOn: "id");

                return result;
            }
        }

        public int Update(Product obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
