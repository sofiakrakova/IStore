using Dapper;
using IStore.Data.Interfaces;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IStore.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public string TableName { get; } // => "orders";
        public string ConnectionString { get; }

        public OrdersRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members

        public int Create(Order obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"INSERT INTO {TableName} VALUE(NULL, @user_id, @address, @paymenttype, @total, @status, @orderdate, @deliverydate);";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS o
                            JOIN users as u
                            ON o.user_id = u.id
                            JOIN userroles AS ur
                            ON u.userrole_id = ur.id
                            WHERE o.id = @id;";

                var orders = connection.Query<Order, User, UserRole, Order>(query, (order, user, userrole) =>
                {
                    order.User = user;
                    order.User.UserRole = userrole;
                    return order;
                },
                splitOn: "id",
                param: new { id });

                return orders.SingleOrDefault();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS o
                            JOIN users as u
                            ON o.user_id = u.id
                            JOIN userroles AS ur
                            ON u.userrole_id = ur.id
                            JOIN products as pr
                            ON o.product_id = pr.product_id;";




                var orders = connection.Query<Order, User, UserRole, Order, Product>(query, (order, user, userrole, product) =>
                 {
                     order.User = user;
                     order.User.UserRole = userrole;
                    // order.OrderItems = product; //?
                     return order;
                 },
                splitOn: "id") ;

                return orders;
            }
        }

        public int Update(Order obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
