using IStore.BusinessLogic.Services.Interfaces;
using IStore.Data.Interfaces;
using IStore.Domain;
using Microsoft.Extensions.Configuration;
using System;

namespace IStore.BusinessLogic.Services
{
    public class ProductsManagementService : IProductsManagementService
    {
        private readonly IConfiguration _configuration;
        private readonly ISupplierProductsRepository _supplierProductsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public ProductsManagementService(IConfiguration configuration, ISupplierProductsRepository supplierProductsRepository, IProductsRepository productsRepository,
            ICategoriesRepository categoriesRepository)
        {
            Protector.SetIfNotNull(ref _configuration, configuration);
            Protector.SetIfNotNull(ref _supplierProductsRepository, supplierProductsRepository);
            Protector.SetIfNotNull(ref _productsRepository, productsRepository);
            Protector.SetIfNotNull(ref _categoriesRepository, categoriesRepository);
        }

        public Product Add(string title, string description, double price, string image, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException($"Invalid title: '{title}'.");
            if (price < 0) throw new ArgumentException($"Invalid price: '{price}'.");

            //TODO: implement
            throw new Exception();
        }

        public Supplier GetAllSuppliersForProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void UploadImage(byte[] imageData)
        {
            throw new NotImplementedException();
        }
    }
}
