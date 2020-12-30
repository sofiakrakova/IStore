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
    public class DiscountsRepository : IDiscountsRepository
    {
        public string TableName { get; } // => "discounts";
        public string ConnectionString { get; }

        public DiscountsRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members

        public int Create(Discount obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"INSERT INTO {TableName} VALUE(NULL, @category_id, @amountpercent);";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }

        public int Delete(int id)
        {
            var affectedRows = CommonQueries.DeleteById<Discount>(ConnectionString, TableName, id);
            return affectedRows;
        }

        public Discount Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS d
                            JOIN categories AS c
                            ON d.category_id = c.id
                            WHERE d.id = @id;";

                var result = connection.Query<Discount, Category, Discount>(query, (discount, category) =>
                {
                    discount.Category = category;
                    return discount;
                },
                splitOn: "id",
                param: new { id });

                return result.SingleOrDefault();
            }
        }

        public IEnumerable<Discount> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS d
                            JOIN categories AS c
                            ON d.category_id = c.id;";

                var result = connection.Query<Discount, Category, Discount>(query, (discount, category) =>
                {
                    discount.Category = category;
                    return discount;
                },
                splitOn: "id");

                return result;
            }
        }

        public int Update(Discount obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
