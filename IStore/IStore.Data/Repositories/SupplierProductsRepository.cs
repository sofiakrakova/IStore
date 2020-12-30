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
    public class SupplierProductsRepository : ISupplierProductsRepository
    {
        public string TableName { get; } // => "supplier_products";
        public string ConnectionString { get; }

        public SupplierProductsRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members

        public int Create(SupplierProduct obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {TableName} VALUE(NULL, @supplier_id, @product_id, @deliverydays);";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }

        public int Delete(int id)
        {
            int affectedRows = CommonQueries.DeleteById<SupplierProduct>(ConnectionString, TableName, id);
            return affectedRows;
        }

        public SupplierProduct Get(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS sp
                            JOIN suppliers AS s
                            ON sp.supplier_id = s.id
                            JOIN products AS p
                            ON sp.product_id = p.id
                            JOIN categories AS c
                            ON p.category_id = c.id
                            WHERE sp.id = @id;";

                var result = connection.Query<SupplierProduct, Supplier, Product, Category, SupplierProduct>(query, (supplierProduct, supplier, product, category) =>
                {
                    supplierProduct.Supplier = supplier;
                    supplierProduct.Product = product;
                    supplierProduct.Product.Category = category;
                    return supplierProduct;
                },
                splitOn: "id",
                param: new { id });

                return result.SingleOrDefault();
            }
        }

        public IEnumerable<SupplierProduct> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"SELECT * FROM {TableName} AS sp
                            JOIN suppliers AS s
                            ON sp.supplier_id = s.id
                            JOIN products AS p
                            ON sp.product_id = p.id
                            JOIN categories AS c
                            ON p.category_id = c.id;";

                var result = connection.Query<SupplierProduct, Supplier, Product, Category, SupplierProduct>(query, (supplierProduct, supplier, product, category) =>
                {
                    supplierProduct.Supplier = supplier;
                    supplierProduct.Product = product;
                    supplierProduct.Product.Category = category;
                    return supplierProduct;
                }, 
                splitOn: "id");

                return result;
            }
        }

        public int Update(SupplierProduct obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
