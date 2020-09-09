using Dapper;
using IStore.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IStore.Data
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly string _connectionString;

        public CommentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Comment obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            using(IDbConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Comment>($"SELECT * FROM comments WHERE comment_id={id}").FirstOrDefault();
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}
