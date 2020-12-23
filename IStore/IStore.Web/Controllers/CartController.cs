using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IStore.Data.Interfaces;
using IStore.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IStore.Web.Controllers
{
    public class CartController : Controller
    {
        IProductsRepository _productsRepository;
        ILogger<CartController> _logger;
        public CartController(IProductsRepository productsRepository, ILogger<CartController> logger)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }

        public IActionResult DeleteItem(int id)
        {
            Response.Cookies.Delete($"product{id}");
            return Redirect($"~/Cart");
        }

        public ViewResult Index()
        {
            //словарь товар-его количество
            Dictionary<int, int> products = new Dictionary<int, int>();

            //общее количество существующих товаров
            int length = _productsRepository.GetAll().Count();

            //смотрим количество товаров в корзине по куки
            for (int index = 0; index < length; index++)
            {
                Product currentProduct = _productsRepository.Get(index);
                string countInfo = Request.Cookies[$"product{index}"];

                if (currentProduct != null && int.TryParse(countInfo, out int count))
                {
                    products.Add(index, count);
                }
            }

            ViewData["length"] = length;
            ViewData["products"] = _productsRepository;

            return View(products);
        }
    }
}
