using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IStore.Data.Interfaces;
using IStore.Domain;
using IStore.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace IStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductsRepository _productsRepository;
        private readonly ICommentsRepository _commentsRepository;
        private readonly IUsersRepository _usersRepository;
        public ProductController(IProductsRepository productsRepository, ILogger<ProductController> logger, ICommentsRepository commentsRepository, 
            IUsersRepository usersRepository)
        { 
            _logger = logger;
            _productsRepository = productsRepository;
            _commentsRepository = commentsRepository;
            _usersRepository = usersRepository;
        }

        // GET: ProductController/Details/<какой-нибудь id>
        public ViewResult Details(int id)
        {
            var productsList = _productsRepository.GetAll().Where(x => x.Category_Id == id);
            return View(productsList);
        }

        // GET: ProductController/About/<какой-нибудь id>
        public ViewResult About(int id)
        {
            Product product = _productsRepository.Get(id);
            if (!Request.Cookies.TryGetValue($"product{id}", out string result))
            {
                ViewData["productCount"] = 0;
            }
            else
            {
                ViewData["productCount"] = result;
            }
            
            ViewData["comments"] = _commentsRepository.GetAll().Where(x => x.Product_Id == id);
            return View(product);
        }

        public IActionResult AddToCard(int id)
        {
            string productId = $"product{id}";
            CookieOptions options = new CookieOptions();
            if (!Request.Cookies.TryGetValue(productId, out string result))
            {
                AddCookies(productId, "1");
            }
            else
            {
                AddCookies(productId, $"{int.Parse(Request.Cookies[productId]) + 1}");
            }
            return Redirect($"~/Product/About/{id}");
        }

        public IActionResult AddComment(string text, int product_id, int user_id)
        {

            Comment comment = new Comment
            {
                Id = _commentsRepository.GetAll().Count(),
                User = _usersRepository.Get(user_id),
                User_Id = user_id,
                Product = _productsRepository.Get(product_id),
                Product_Id = product_id,
                Text = text
            };
            _commentsRepository.Create(comment);
            return Redirect($"~/Product/About/{product_id}");
        }

        private void AddCookies(string key, string value)
        {
            CookieOptions options = new CookieOptions();
            Response.Cookies.Append(key, value, options);
        }
    }
}
