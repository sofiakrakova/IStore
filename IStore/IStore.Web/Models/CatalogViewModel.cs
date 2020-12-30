using IStore.BusinessLogic.Models;
using IStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IStore.Web.Models
{
    public class CatalogViewModel
    {
        public IEnumerable<RootCategoryModel> RootCategories { get; set; }

        [Obsolete]
        public IEnumerable<Category> AllCategories { get; set; }

        [Obsolete]
        public IEnumerable<Category> TopCategories { get { return AllCategories.Where(x => x.Parent_Id == null); } }

        [Obsolete]
        public IEnumerable<Category> GetChildCategories(int parentId)
        {
            return AllCategories.Where(x => x.Parent_Id == parentId);
        }
    }
}
