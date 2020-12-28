using IStore.BusinessLogic.Models;
using IStore.BusinessLogic.Services.Interfaces;
using IStore.Data.Interfaces;
using IStore.Domain;
using IStore.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IStore.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ICategoriesService _categoriesService;
        private readonly IProductsRepository _productsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUsersRepository _userRepository;

        public AdministrationController(ICategoriesRepository categoriesRepository, ICategoriesService categoriesService, IProductsRepository productsRepository,
            IOrdersRepository ordersRepository, IUsersRepository _users)
        {
            _categoriesRepository = categoriesRepository ?? throw new ArgumentNullException(nameof(categoriesRepository));
            _categoriesService = categoriesService ?? throw new ArgumentNullException(nameof(categoriesService));
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            _ordersRepository = ordersRepository;
            _userRepository = _users;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Order management
        public ViewResult OrderManagement()
        {
            return View("OrderManagement", _ordersRepository);
        }

        public IActionResult MakeChangesInOrder(int id, string status)
        {
            Order order = _ordersRepository.Get(id);
            order.Status = status;
            _ordersRepository.Delete(order.Id);
            _ordersRepository.Create(order);
            return Redirect("~/Administration/OrderManagement");
        }

        #endregion

        #region CheckIn

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
        #endregion

        #region Catalog management

        [HttpGet]
        public IActionResult CatalogManagement()
        {
            CatalogViewModel catalogViewModel = new CatalogViewModel();

            var allCategories = _categoriesService.GetRootCategories();
            catalogViewModel.RootCategories = new List<RootCategoryModel>(allCategories);

            return View("CatalogManagement", catalogViewModel);
        }


        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            _categoriesRepository.DeleteWithChildren(categoryId);

            return RedirectToAction("CatalogManagement");
        }

        [HttpPost]
        public IActionResult AddCategory(string title, int parentId, string isRootCategory)
        {
            //TODO: better validate title
            if (string.IsNullOrWhiteSpace(title))
                return RedirectToAction("CatalogManagement");

            //TODO:find a better way to pass checkbox value
            if (isRootCategory != null && isRootCategory.Equals("on"))
            {
                _categoriesRepository.Create(new Category() { Title = title });
            }
            else
            {
                _categoriesRepository.Create(new Category() { Title = title, Parent_Id = parentId });
            }

            return RedirectToAction("CatalogManagement");
        }

        #endregion
    }
}
