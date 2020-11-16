using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IStore.Data.Interfaces;
using IStore.Domain;
using IStore.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IStore.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IProductsRepository _productsRepository;

        public AdministrationController(ICategoriesRepository categoriesRepository, IProductsRepository productsRepository)
        {
            _categoriesRepository = categoriesRepository ?? throw new ArgumentNullException(nameof(categoriesRepository));
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CheckIn()
        {
            ProductViewModel productViewModel = new ProductViewModel() { Categories = _categoriesRepository.GetAll() };
            return View("CheckIn", productViewModel);
        }

        [HttpPost]
        public IActionResult CheckIn(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Title = productViewModel.Title,
                    Description = productViewModel.Description,
                    Price = productViewModel.Price,
                    Category_Id = productViewModel.CategoryId.Value,
                    Image = UploadFile(productViewModel.Image).GetAwaiter().GetResult(),
                };


                //TODO: Save
                //_productsRepository.Create(product);

                return View("Index");
            }

            return View("CheckIn");
        }

        private async Task<string> UploadFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = @"C:\Users\Andrey\source\repos\lessons\SofiaK\Coursework\data\images\upload\" + uploadedFile.FileName;

                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadedFile.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)uploadedFile.Length);
                }

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                return path;
            }

            return string.Empty;
        }
    }
}
