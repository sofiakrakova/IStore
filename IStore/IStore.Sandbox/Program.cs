using IStore.Data;
using IStore.Domain;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace IStore.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            DbConnectionStringBuilder sb = new DbConnectionStringBuilder();
            sb.Add("Server", "localhost");
            sb.Add("Database", "istoredb");
            sb.Add("User Id", "root");
            sb.Add("Password", "admin");

            CategoryRepository categoryRepository = new CategoryRepository(sb.ConnectionString);
            List<Category> categories = categoryRepository.GetAll().ToList();

            var headphones = categories.Single(x => x.Title == "Headphones");
            headphones.Active = false;
            categoryRepository.Update(headphones);
        }
    }
}
