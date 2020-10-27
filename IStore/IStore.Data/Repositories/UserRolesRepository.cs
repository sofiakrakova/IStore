using IStore.Data.Common;
using IStore.Data.Interfaces;
using IStore.Domain;
using System;
using System.Collections.Generic;

namespace IStore.Data.Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {
        public string TableName { get; } // => "userroles";
        public string ConnectionString { get; }

        public UserRolesRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members

        public int Create(UserRole obj)
        {
            throw new DBOperationNotSupportedException();
        }

        public int Delete(int id)
        {
            throw new DBOperationNotSupportedException();
        }

        public UserRole Get(int id)
        {
            return CommonQueries.GetById<UserRole>(ConnectionString, TableName, id);
        }

        public IEnumerable<UserRole> GetAll()
        {
            return CommonQueries.GetAll<UserRole>(ConnectionString, TableName);
        }

        public int Update(UserRole obj)
        {
            throw new DBOperationNotSupportedException();
        }
        #endregion
    }
}
