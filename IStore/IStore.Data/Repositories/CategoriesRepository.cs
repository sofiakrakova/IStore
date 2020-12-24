﻿using Dapper;
using IStore.Data.Common;
using IStore.Data.Interfaces;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IStore.Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        public string TableName { get; } //  => "categories";
        public string ConnectionString { get; }

        public CategoriesRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members

        public int Create(Category obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {TableName} VALUE(NULL, @parent_id, @title, @active);";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }

        public int Delete(int id)
        {
            int affectedRows = CommonQueries.DeleteById<Category>(ConnectionString, TableName, id);
            return affectedRows;
        }

        public Category Get(int id)
        {
            return CommonQueries.GetById<Category>(ConnectionString, TableName, id);
        }

        public IEnumerable<Category> GetAll()
        {
            return CommonQueries.GetAll<Category>(ConnectionString, TableName);
        }

        public int Update(Category obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"UPDATE {TableName} 
                            SET parent_id = @parent_id, title = @title, active = @active
                            WHERE id = @id;";

                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }
        #endregion
    }
}
