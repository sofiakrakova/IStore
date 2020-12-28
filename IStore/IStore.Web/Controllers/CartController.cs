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
        IOrdersRepository _ordersRepository;
        ILogger<CartController> _logger;
        public CartController(IProductsRepository productsRepository, ILogger<CartController> logger, IOrdersRepository ordersRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
        }

        public IActionResult AddOrder(string country, string area, string city, string street, string house, string kv, string paymentType, DateTime date)
        {
            string address = $"{country}, {area}, г. {city}, ул. {street}, д. {house}, кв. {kv}";
            Order order = new Order
            {
                OrderItems = CreateOrderList(),
                OrderDate = DateTime.Now,
                DeliveryDate = date, 
                Address = address,
                Status = "Created",
                PaymentType = paymentType,
                Id = _ordersRepository.GetAll().Count(),
                User_Id = 1,
            };
            _ordersRepository.Create(order);
            return Redirect($"~/Cart");
        }

        public IActionResult DeleteItem(int id)
        {
            DeleteIdCookie(id);
            return Redirect($"~/Cart");
        }

        private IEnumerable<OrderItem> CreateOrderList()
        {
            Dictionary<int, int> products = GetProducts();
            List<OrderItem> items = new List<OrderItem>();

            foreach (var item in products)
            {
                items.Add(new OrderItem
                {
                    Product = _productsRepository.Get(item.Key),
                    Qty = item.Value,
                });
                DeleteIdCookie(item.Key);
            }
            return items;
        }

        private void DeleteIdCookie(int id) => Response.Cookies.Delete($"product{id}");

        private Dictionary<int, int> GetProducts()
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
            return products;
        }

        public ViewResult Index()
        {
            
            Dictionary<int, int> products = GetProducts();

            ViewData["products"] = _productsRepository;

            return View(products);
        }
    }
}
