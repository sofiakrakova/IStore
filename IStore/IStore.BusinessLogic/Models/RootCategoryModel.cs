using IStore.Domain;
using System;
using System.Collections.Generic;

namespace IStore.BusinessLogic.Models
{
    public class RootCategoryModel
    {
        public Category Category { get; }
        public ICollection<Category> SubCategories { get; }

        public RootCategoryModel(Category category)
        {
            Category = category ?? throw new ArgumentNullException(nameof(category));
            SubCategories = new HashSet<Category>();
        }
    }
}
