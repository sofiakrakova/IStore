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
    public class OrderItemsRepository : IOrderItemsRepository
    {
        public string TableName { get; } // => "order_items";
        public string ConnectionString { get; }

        public OrderItemsRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members

        public int Create(OrderItem obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"INSERT INTO {TableName} VALUE(NULL, @product_id, @qty, @order_id);";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }

        public int Delete(int id)
        {
            var affectedRows = CommonQueries.DeleteById<OrderItem>(ConnectionString, TableName, id);
            return affectedRows;
        }

        //Shallow get: not all of nested types are filled
        public OrderItem Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS i
                            JOIN products AS p
                            ON i.product_id = p.id
                            JOIN orders AS o
                            ON i.order_id = o.id
                            WHERE i.id = @id;";

                var result = connection.Query<OrderItem, Product, Order, OrderItem>(query, (orderItem, product, order) =>
                {
                    orderItem.Product = product;
                    orderItem.Order = order;
                    return orderItem;
                },
                splitOn: "id",
                param: new { id });

                return result.SingleOrDefault();
            }
        }

        //Shallow get: not all of nested types are filled
        public IEnumerable<OrderItem> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS i
                            JOIN products AS p
                            ON i.product_id = p.id
                            JOIN orders AS o
                            ON i.order_id = o.id";

                var result = connection.Query<OrderItem, Product, Order, OrderItem>(query, (orderItem, product, order) =>
                {
                    orderItem.Product = product;
                    orderItem.Order = order;
                    return orderItem;
                },
                splitOn: "id");

                return result;
            }
        }

        public int Update(OrderItem obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
