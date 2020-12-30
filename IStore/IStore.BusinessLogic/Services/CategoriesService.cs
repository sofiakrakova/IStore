using IStore.BusinessLogic.Models;
using IStore.BusinessLogic.Services.Interfaces;
using IStore.Data.Interfaces;
using IStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IStore.BusinessLogic.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            Protector.SetIfNotNull(ref _categoriesRepository, categoriesRepository);
        }

        public IEnumerable<RootCategoryModel> GetRootCategories()
        {
            var allCategories = _categoriesRepository.GetAll();

            var rootCategories = allCategories.Where(x => !x.Parent_Id.HasValue);
            List<RootCategoryModel> rootModels = rootCategories.Select(x => new RootCategoryModel(x)).ToList();

            var groups = allCategories.GroupBy(x => x.Parent_Id);
            foreach (var root in rootModels)
            {
                var subCategories = groups.FirstOrDefault(x => x.Key == root.Category.Id);
                if (subCategories == null)
                    continue;

                foreach (var subCategory in subCategories)
                {
                    root.SubCategories.Add(subCategory);
                }
            }

            return rootModels;
        }

        public Category CreateCategory(string name, Category root = null)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));

            if (root == null) //create new root category
            {
                var existingRootCategory = _categoriesRepository.GetAllByName(name).FirstOrDefault(x => x.Title == name && !x.Parent_Id.HasValue);
                if (existingRootCategory != null)
                    throw new Exception($"Cannot create category. Root category with title '{name}' already exists.");

                var newRootCategory = new Category() { Parent_Id = null, Title = name };
                _categoriesRepository.Create(newRootCategory);

                return _categoriesRepository.GetAllByName(name).FirstOrDefault(x => x.Title == name);
            }
            else
            {
                var existingCategory = _categoriesRepository.GetAllByName(name).FirstOrDefault(x => x.Title == name && x.Parent_Id.Value == root.Id);
                if (existingCategory != null)
                    throw new Exception($"Cannot create category. Category with title '{name}' and root '{root.Title}' already exists.");

                var newCategory = new Category() { Parent_Id = root.Id, Title = name };
                _categoriesRepository.Create(newCategory);

                return _categoriesRepository.GetAllByName(name).FirstOrDefault(x => x.Title == name && x.Parent_Id.Value == root.Id);
            }
        }
    }
}
