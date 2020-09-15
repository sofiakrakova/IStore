using IStore.Domain;
using System.Collections.Generic;
using System.Linq;

namespace IStore.Web.Models.Catalogue
{
    public class CatalogueViewModel
    {
        public IEnumerable<Category> AllCategories { get; set; }

        public IEnumerable<Category> TopCategories { get { return AllCategories.Where(x => x.Parent_Id == null); } }
        public IEnumerable<Category> GetChildCategories(int parentId)
        {
            return AllCategories.Where(x => x.Parent_Id == parentId);
        }
    }
}
