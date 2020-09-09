using IStore.Data;
using IStore.Domain;
using System;
using System.Data.Common;
using System.Text;

namespace IStore.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DbConnectionStringBuilder sb = new DbConnectionStringBuilder();
            sb.Add("Server", "localhost");
            sb.Add("Database", "istoredb");
            sb.Add("User Id", "root");
            sb.Add("Password", "admin");

            CommentRepository commentRepository = new CommentRepository(sb.ConnectionString);
            Comment comment = commentRepository.Get(1);
            Console.WriteLine(comment.Text);

            Console.ReadLine();
        }
    }
}
