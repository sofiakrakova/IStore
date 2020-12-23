using IStore.BusinessLogic.Services;
using IStore.Data.Interfaces;
using IStore.Data.Repositories;
using IStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IStore.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ICategoriesRepository _categoriesRepository;

        public CatalogController(ICategoriesRepository categoriesRepository, ILogger<CatalogController> logger)
        {
            _logger = logger;
            _categoriesRepository = categoriesRepository;
        }
        
        public ViewResult Index()
        {
            CatalogViewModel catalogueViewModel = new CatalogViewModel();
            
            var allCategories = _categoriesRepository.GetAll();
            catalogueViewModel.AllCategories = allCategories;

            return View(catalogueViewModel);
        }
    }
}
