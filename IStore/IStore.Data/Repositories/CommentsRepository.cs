using Dapper;
using IStore.Data.Common;
using IStore.Data.Interfaces;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IStore.Data.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        public string TableName { get; } // => "comments";
        public string ConnectionString { get; }

        public CommentsRepository(string connectionString, string tableName)
        {
            TableName = tableName ?? throw new ArgumentException(nameof(tableName));
            ConnectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
        }

        #region IRepository<T> members

        public int Create(Comment obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"INSERT INTO {TableName} VALUE(NULL, @credentials, @email, @passwordhash, @birthday, @comment, @userrole_id);";
                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }
         
        public int Delete(int id)
        {
            throw new DBOperationNotSupportedException();
        }

        public Comment Get(int id)
        {
            return CommonQueries.GetById<Comment>(ConnectionString, TableName, id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return CommonQueries.GetAll<Comment>(ConnectionString, TableName);
        }

        public int Update(Comment obj)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"UPDATE {TableName} 
                            SET parent_id = @parent_id, text = @text, product_id = @product_id, user_id = @user_id
                            WHERE id = @id;";

                var affectedRows = connection.Execute(query, obj);
                return affectedRows;
            }
        }
        #endregion

        #region ICommentsRepository members

        //How to delete ALL chain of nested comments?
        public int DeleteWithChildren(int id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnectionString))
            {
                var query = $@"DELETE FROM {TableName} WHERE parent_id = @id OR id = @id;";
                var affectedRows = connection.Execute(query, new { id });
                return affectedRows;
            }
        }

        public int Attach(int parentId, Comment child)
        {
            var parent = Get(parentId);

            if (parent == null)
                throw new Exception("Could not find parent.");

            var affecredRows = Create(child);
            return affecredRows;
        }

        public int CreateRoot(Comment comment)
        {
            if (comment.Parent_Id.HasValue)
                throw new Exception("Comment Id not the root because it has not null Parent_Id.");

            var affecredRows = Create(comment);
            return affecredRows;
        }
        #endregion
    }
}
