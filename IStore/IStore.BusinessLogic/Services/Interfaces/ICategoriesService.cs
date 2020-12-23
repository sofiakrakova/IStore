using IStore.BusinessLogic.Models;
using IStore.Domain;
using System.Collections.Generic;

namespace IStore.BusinessLogic.Services.Interfaces
{
    public interface ICategoriesService
    {
        IEnumerable<RootCategoryModel> GetRootCategories();

        Category CreateCategory(string name, Category root = null);
    }
}
